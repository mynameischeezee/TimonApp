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

    public Task<DataAccess.Models.MoneyRecord> GetLastTransactionFromBank(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.MoneyRecord> CreateMoneyRecord(DataAccess.Models.User user, DataAccess.Models.MoneyRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.MoneyRecord> DeleteMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.MoneyRecord> UpdateMoneyRecord(DataAccess.Models.MoneyRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DataAccess.Models.MoneyRecord>> GetAllUsersMoneyRecords(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public Task<DataAccess.Models.MoneyRecord?> GetMoneyRecord(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }
}