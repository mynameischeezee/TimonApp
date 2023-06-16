using MonoBankApi.Services;
using Timon.Abstract.Services.MoneyRecord;
using Timon.DataAccess.Models;
using Timon.DataAccess.UnitOfWork;

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
}