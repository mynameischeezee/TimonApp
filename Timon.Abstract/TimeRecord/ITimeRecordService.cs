namespace Timon.Abstract.TimeRecord;

public interface ITimeRecordService<TRerecord, in TUser>
    where TRerecord : class
    where TUser : class
{
    TRerecord CreateTimeRecord();
    TRerecord DeleteTimeRecord(TRerecord record);
    TRerecord UpdateTimeRecord(TRerecord record);
    IEnumerable<TRerecord> GetAllUsersTimeRecords(TUser user);
    TRerecord GetTimeRecord(TUser user);
}