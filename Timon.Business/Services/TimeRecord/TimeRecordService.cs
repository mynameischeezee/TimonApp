using Timon.Abstract.Services.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Services.TimeRecord;

public class TimeRecordService : ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public TimeRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataAccess.Models.TimeRecord> CreateTimeRecord(DataAccess.Models.User user, DataAccess.Models.TimeRecord record)
    {
        record.CreatedAt = DateTime.Now;
        record.UpdatedAt = DateTime.Now;
        await _unitOfWork.TimeRecords.Insert(record);
        await _unitOfWork.Save();
        var userTimeRecord = new DataAccess.Models.UserTimeRecord()
        {
            UserId = user.Id,
            TimeRecordId = record.Id,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        await _unitOfWork.UserTimeRecords.Insert(userTimeRecord);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.TimeRecord> DeleteTimeRecord(DataAccess.Models.TimeRecord record)
    {
        var userTimeRecord = await _unitOfWork.UserTimeRecords.Get(x => x.TimeRecord.Id == record.Id);
        await _unitOfWork.UserTimeRecords.Delete(userTimeRecord.Id);
        await _unitOfWork.TimeRecords.Delete(record.Id);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.TimeRecord> UpdateTimeRecord(DataAccess.Models.TimeRecord record)
    {
        record.UpdatedAt = DateTime.Now;
        _unitOfWork.TimeRecords.Update(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<IEnumerable<DataAccess.Models.TimeRecord>> GetAllUsersTimeRecords(DataAccess.Models.User user)
    {
        var userTimeRecords = (await _unitOfWork.UserTimeRecords.GetAll(x => x.User.Id == user.Id)).ToList();
        var userTimeRecordsId = userTimeRecords.Select(x => x.TimeRecordId);
        var timeRecords = (await _unitOfWork.TimeRecords.GetAll(x => userTimeRecordsId.Contains(x.Id))).ToList();
        return timeRecords.ToList();
    }

    public async Task<DataAccess.Models.TimeRecord?> GetTimeRecord(int id)
    {
        var timeRecord = await _unitOfWork.TimeRecords.Get(x => x.Id == id);
        return timeRecord;
    }
}