namespace Timon.Abstract.Services.Statistics;

public interface IStatisticsService<in TUser> where TUser : class
{
    Task<IEnumerable<int>> GenerateMoneyRecordsStatistics(TUser user, DateTime from, DateTime to);
    Task<IEnumerable<TimeSpan>> GenerateTimeRecordsStatistics(TUser user, DateTime from, DateTime to);
}