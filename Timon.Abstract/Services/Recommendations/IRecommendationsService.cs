namespace Timon.Abstract.Services.Recommendations;

public interface IRecommendationsService<in TUser> where TUser : class
{
    Task<IEnumerable<string>> GetTwoWorstCategoriesNames(TUser user);
    Task<string> GetWorstTimeRecordsCategory(TUser user);
    Task<string> GetWorstMoneyRecordCategory(TUser user);
}