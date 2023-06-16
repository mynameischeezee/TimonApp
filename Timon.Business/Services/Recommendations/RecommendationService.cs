using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.Recommendations;
using Timon.Abstract.Services.TimeRecord;
using Timon.DataAccess.Models;

namespace Timon.Business.Services.Recommendations;

public class RecommendationService : IRecommendationsService<DataAccess.Models.User>
{
    private readonly ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> _timeRecordService;
    private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> _moneyRecordService;
    private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;
    public RecommendationService(ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> timeRecordService, IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> moneyRecordService, ICategoryService<Category, DataAccess.Models.User> categoryService)
    {
        _timeRecordService = timeRecordService;
        _moneyRecordService = moneyRecordService;
        _categoryService = categoryService;
    }
    public async Task<IEnumerable<string>> GetTwoWorstCategoriesNames(DataAccess.Models.User user)
    {
        var allUserCategories = (await _categoryService.GetAllUsersCategories(user)).ToList();
        var allUserCategoriesId = allUserCategories.Select(x=> x.Id);
        var allUserMoneyRecords = await _moneyRecordService.GetAllUsersMoneyRecords(user);
        var allUserTimeRecords = await _timeRecordService.GetAllUsersTimeRecords(user);

        var worstMoneyRecordsCategories = allUserMoneyRecords.Where(x => allUserCategoriesId.Contains(x.CategoryId))
            .OrderByDescending(x => x.Amount).ToList();

        var worstTimeRecordsCategories = allUserTimeRecords.Where(x => allUserCategoriesId.Contains(x.CategoryId))
            .OrderByDescending(x => Convert.ToInt32(x.Duration)).ToList();

        var worstCategories = new List<int>
        {
            worstMoneyRecordsCategories[0].CategoryId,
            worstMoneyRecordsCategories[1].CategoryId,
            worstTimeRecordsCategories[0].CategoryId,
            worstTimeRecordsCategories[1].CategoryId,
        };
        var worstCategoriesNames = allUserCategories.Where(x => worstCategories.Contains(x.Id)).Select(x => x.Name).ToList();
        return worstCategoriesNames.ToList();
    }

    public async Task<string> GetWorstTimeRecordsCategory(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetWorstMoneyRecordCategory(DataAccess.Models.User user)
    {
        throw new NotImplementedException();
    }
}