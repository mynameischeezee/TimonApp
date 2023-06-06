namespace Timon.Abstract.MoneyRecord;

public interface IMoneyRecordService<TRecord, in TUser> 
    where TRecord : class 
    where TUser : class
{
    Task<TRecord> GetLastTransactionFromBank();
    Task<TRecord> CreateMoneyRecord(TUser user, TRecord record);
    Task<TRecord> DeleteMoneyRecord(TRecord record);
    Task<TRecord> UpdateMoneyRecord(TRecord record);
    Task<IEnumerable<TRecord>> GetAllUsersMoneyRecords(TUser user);
    Task<TRecord?> GetMoneyRecord(TUser user);
}