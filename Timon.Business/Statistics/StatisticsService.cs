using Timon.Abstract.MoneyRecord;
using Timon.Abstract.Statistics;
using Timon.Abstract.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Statistics;

public class StatisticsService : IStatisticsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> _timeRecordService;
    private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> _moneyRecordService;

    public StatisticsService(IUnitOfWork unitOfWork, 
        ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> timeRecordService, 
        IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> moneyRecordService)
    {
        _unitOfWork = unitOfWork;
        _timeRecordService = timeRecordService;
        _moneyRecordService = moneyRecordService;
    }

    public IEnumerable<int> GenerateMoneyRecordsStatistics(DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> GenerateTimeRecordsStatistics(DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }
}