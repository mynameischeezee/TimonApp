using Timon.Abstract.MoneyRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.MoneyRecord;

public class MoneyRecordService : IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public MoneyRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public DataAccess.Models.MoneyRecord GetLastTransactionFromBank()
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.MoneyRecord CreateMoneyRecord()
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.MoneyRecord DeleteMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.MoneyRecord UpdateMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DataAccess.Models.MoneyRecord> GetAllUsersMoneyRecords(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.MoneyRecord GetMoneyRecord(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }
}