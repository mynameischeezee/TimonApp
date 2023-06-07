namespace Timon.Abstract.Statistics;

public interface IStatisticsService<TUser> where TUser : class
{
    Task<IEnumerable<int>> GenerateMoneyRecordsStatistics(TUser user, DateTime from, DateTime to);
    Task<IEnumerable<TimeSpan>> GenerateTimeRecordsStatistics(TUser user, DateTime from, DateTime to);
}