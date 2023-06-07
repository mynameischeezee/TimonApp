using Timon.Abstract.MoneyRecord;
using Timon.Abstract.Statistics;
using Timon.Abstract.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Statistics;

public class StatisticsService : IStatisticsService<DataAccess.Models.User>
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

    public async Task<IEnumerable<int>> GenerateMoneyRecordsStatistics(DataAccess.Models.User user, DateTime from, DateTime to)
    {
        var moneyRecords = await _moneyRecordService.GetAllUsersMoneyRecords(user);
        var filteredMoneyRecords = moneyRecords.Where(x => x.Date >= from && x.Date <= to).Select(y => y.Amount);
        return filteredMoneyRecords;
    }

    public async Task<IEnumerable<TimeSpan>> GenerateTimeRecordsStatistics(DataAccess.Models.User user, DateTime from, DateTime to)
    {
        var timeRecords = await _timeRecordService.GetAllUsersTimeRecords(user);
        var filteredTimeRecords = timeRecords.Where(x => x.DateFrom >= from && x.DateTo <= to).Select(y => y.DateTo-y.DateFrom);
        return filteredTimeRecords;
    }
}