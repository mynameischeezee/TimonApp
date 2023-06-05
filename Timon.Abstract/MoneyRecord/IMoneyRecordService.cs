namespace Timon.Abstract.MoneyRecord;

public interface IMoneyRecordService<TRecord, in TUser> 
    where TRecord : class 
    where TUser : class
{
    TRecord GetLastTransactionFromBank();
    TRecord CreateMoneyRecord();
    TRecord DeleteMoneyRecord(TRecord record);
    TRecord UpdateMoneyRecord(TRecord record);
    IEnumerable<TRecord> GetAllUsersMoneyRecords(TUser user);
    TRecord GetMoneyRecord(TUser user);
}