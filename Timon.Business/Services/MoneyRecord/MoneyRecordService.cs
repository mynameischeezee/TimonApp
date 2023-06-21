using Going.Plaid;
using Going.Plaid.Entity;
using Going.Plaid.Institutions;
using Going.Plaid.Item;
using Going.Plaid.Link;
using Going.Plaid.Sandbox;
using Going.Plaid.Transactions;
using MonoBankApi.Services;
using System.Collections.Generic;
using Timon.Abstract.Services.MoneyRecord;
using Timon.DataAccess.Models;
using Timon.DataAccess.UnitOfWork;
using Environment = System.Environment;

namespace Timon.Business.Services.MoneyRecord;

public class MoneyRecordService : IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMonoPersonal _connector;

    public MoneyRecordService(IUnitOfWork unitOfWork, IMonoPersonal connector)
    {
        _unitOfWork = unitOfWork;
        _connector = connector;
    }

    public async Task<DataAccess.Models.MoneyRecord> GetLastTransactionFromBank(DataAccess.Models.User user)
    {
        //see: "https://api.monobank.ua/docs/"
        const string defaultAcc = "0";
        var monoTimeRecordsCollection = await _connector.ReturnStatementAsync(DateTime.Now - TimeSpan.FromDays(1), DateTime.Now, defaultAcc);
        var lastMonoTransaction = monoTimeRecordsCollection.First();
        var moneyRecord = new DataAccess.Models.MoneyRecord()
        {
            Name = "",
            Description = lastMonoTransaction.Description,
            Amount = Math.Abs((int)lastMonoTransaction.Amount / 100),
            Date = DateTime.Now,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        return moneyRecord;

    }

    public async Task<DataAccess.Models.MoneyRecord> CreateMoneyRecord(DataAccess.Models.User user, DataAccess.Models.MoneyRecord record)
    {
        record.CreatedAt = DateTime.Now;
        record.UpdatedAt = DateTime.Now;
        await _unitOfWork.MoneyRecords.Insert(record);
        await _unitOfWork.Save();
        var userMoneyRecord = new UserMoneyRecord()
        {
            UserId = user.Id,
            MoneyRecordId = record.Id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        await _unitOfWork.UserMoneyRecords.Insert(userMoneyRecord);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.MoneyRecord> DeleteMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        var userMoneyRecord = await _unitOfWork.UserMoneyRecords.Get(x => x.MoneyRecord.Id == record.Id);
        await _unitOfWork.UserMoneyRecords.Delete(userMoneyRecord.Id);
        await _unitOfWork.MoneyRecords.Delete(record.Id);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.MoneyRecord> UpdateMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        record.UpdatedAt = DateTime.Now;
        _unitOfWork.MoneyRecords.Update(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<IEnumerable<DataAccess.Models.MoneyRecord>> GetAllUsersMoneyRecords(DataAccess.Models.User user)
    {
        var userMoneyRecords = await _unitOfWork.UserMoneyRecords.GetAll(x => x.User.Id == user.Id);
        var userMoneyRecordsId = userMoneyRecords.Select(x => x.MoneyRecordId);
        var moneyRecords = await _unitOfWork.MoneyRecords.GetAll(x => userMoneyRecordsId.Contains(x.Id));
        return moneyRecords.ToList();
    }

    public async Task<DataAccess.Models.MoneyRecord?> GetMoneyRecord(int id)
    {
        var moneyRecord = await _unitOfWork.MoneyRecords.Get(x => x.Id == id);
        return moneyRecord;
    }

    public async Task<DataAccess.Models.MoneyRecord?> GetMoneyRecordFromPlaid(DataAccess.Models.User user)
    {
        var _client = new PlaidClient(Going.Plaid.Environment.Sandbox, clientId: "6490859ef632490018bec882",
            secret: "74e358e90ff1c757eaf6e30b60d4df");
        var publicTokenResponse = await _client.SandboxPublicTokenCreateAsync(
            new SandboxPublicTokenCreateRequest()
            {
               InstitutionId = "ins_1",
               InitialProducts = new[] { Products.Transactions }
            });
        var accessTokenResponse = await _client.ItemPublicTokenExchangeAsync(new ItemPublicTokenExchangeRequest()
        {
            PublicToken = publicTokenResponse.PublicToken
        });
        var accessToken = accessTokenResponse.AccessToken;
        Thread.Sleep(2000);
        var r = new Random();
        var transactionsResponse = await _client.TransactionsGetAsync(new TransactionsGetRequest()
        {
            AccessToken = accessToken,
            StartDate = DateOnly.MinValue,
            EndDate = DateOnly.FromDateTime(DateTime.Now),
            Options = new TransactionsGetRequestOptions(){Count = 30}
        });
        var transaction = transactionsResponse.Transactions[r.Next(transactionsResponse.Transactions.Count)];
        var moneyRecord = new DataAccess.Models.MoneyRecord()
        {
            Name = transaction.Name!,
            Description = transaction.MerchantName,
            Amount = Math.Abs((int)(transaction.Amount!*36)),
            Date = DateTime.Now,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        return moneyRecord;
    }
}