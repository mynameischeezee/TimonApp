namespace Timon.Abstract.Statistics;

public interface IStatisticsService
{
    IEnumerable<int> GenerateMoneyRecordsStatistics(DateTime from, DateTime to);
    IEnumerable<int> GenerateTimeRecordsStatistics(DateTime from, DateTime to);
}