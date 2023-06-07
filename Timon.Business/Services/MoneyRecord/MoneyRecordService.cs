﻿using MonoBankApi.Services;
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
        var monoTimeRecordsCollection = await _connector.ReturnStatementAsync(DateTime.Now, DateTime.Now - TimeSpan.FromHours(1));
        var lastMonoTransaction = monoTimeRecordsCollection.Last();
        var moneyRecord = new DataAccess.Models.MoneyRecord()
        {
            Name = "",
            Description = lastMonoTransaction.Description,
            Amount = (int)lastMonoTransaction.Amount,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        return await CreateMoneyRecord(user, moneyRecord);

    }

    public async Task<DataAccess.Models.MoneyRecord> CreateMoneyRecord(DataAccess.Models.User user, DataAccess.Models.MoneyRecord record)
    {
        await _unitOfWork.MoneyRecords.Insert(record);
        var userMoneyRecord = new UserMoneyRecord()
        {
            User = user,
            MoneyRecord = record,
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
        return userMoneyRecords.ToList().Select(x => x.MoneyRecord);
    }

    public async Task<DataAccess.Models.MoneyRecord?> GetMoneyRecord(int id)
    {
        var moneyRecord = await _unitOfWork.MoneyRecords.Get(x => x.Id == id);
        return moneyRecord;
    }
}