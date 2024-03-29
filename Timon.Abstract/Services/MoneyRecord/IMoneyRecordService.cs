﻿namespace Timon.Abstract.Services.MoneyRecord;

public interface IMoneyRecordService<TRecord, in TUser>
    where TRecord : class
    where TUser : class
{
    Task<TRecord> GetLastTransactionFromBank(TUser user);
    Task<TRecord> CreateMoneyRecord(TUser user, TRecord record);
    Task<TRecord> DeleteMoneyRecord(TRecord record);
    Task<TRecord> UpdateMoneyRecord(TRecord record);
    Task<IEnumerable<TRecord>> GetAllUsersMoneyRecords(TUser user);
    Task<TRecord?> GetMoneyRecord(int id);

    Task<TRecord?> GetMoneyRecordFromPlaid(TUser user);
}