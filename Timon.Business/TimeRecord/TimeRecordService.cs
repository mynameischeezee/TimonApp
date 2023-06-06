using Timon.Abstract.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.TimeRecord;

public class TimeRecordService : ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public TimeRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<DataAccess.Models.TimeRecord> CreateTimeRecord(DataAccess.Models.User user, DataAccess.Models.TimeRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.TimeRecord> DeleteTimeRecord(DataAccess.Models.TimeRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.TimeRecord> UpdateTimeRecord(DataAccess.Models.TimeRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DataAccess.Models.TimeRecord>> GetAllUsersTimeRecords(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.TimeRecord?> GetTimeRecord(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }
}