namespace Timon.Abstract.Services.Statistics;

public interface IStatisticsService<in TUser, TCategory, TMoneyRecord, TTimeRecord>
    where TUser : class
    where TCategory : class
    where TMoneyRecord : class
    where TTimeRecord : class
{
    Task<IEnumerable<double>> GenerateMoneyRecordsStatistics(TUser user, DateTime from, DateTime to);
    Task<IEnumerable<double>> GenerateTimeRecordsStatistics(TUser user, DateTime from, DateTime to);
    Task<Dictionary<TCategory, double>> GenerateCategoriesStatistics(TUser user, DateTime from, DateTime to);
}