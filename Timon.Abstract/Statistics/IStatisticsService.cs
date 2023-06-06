namespace Timon.Abstract.Statistics;

public interface IStatisticsService
{
    Task<IEnumerable<int>> GenerateMoneyRecordsStatistics(DateTime from, DateTime to);
    Task<IEnumerable<int>> GenerateTimeRecordsStatistics(DateTime from, DateTime to);
}