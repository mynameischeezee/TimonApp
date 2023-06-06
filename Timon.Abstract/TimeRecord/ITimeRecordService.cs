namespace Timon.Abstract.TimeRecord;

public interface ITimeRecordService<TRecord, in TUser>
    where TRecord : class
    where TUser : class
{
    Task<TRecord> CreateTimeRecord(TUser user, TRecord record);
    Task<TRecord> DeleteTimeRecord(TRecord record);
    Task<TRecord> UpdateTimeRecord(TRecord record);
    Task<IEnumerable<TRecord>> GetAllUsersTimeRecords(TUser user);
    Task<TRecord?> GetTimeRecord(TUser user);
}