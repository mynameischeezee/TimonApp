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

    public DataAccess.Models.TimeRecord CreateTimeRecord()
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.TimeRecord DeleteTimeRecord(DataAccess.Models.TimeRecord record)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.TimeRecord UpdateTimeRecord(DataAccess.Models.TimeRecord record)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DataAccess.Models.TimeRecord> GetAllUsersTimeRecords(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.TimeRecord GetTimeRecord(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }
}