using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.Statistics;
using Timon.Abstract.Services.TimeRecord;
using Timon.Business.Dto;
using Timon.DataAccess.Models;
using Category = Timon.DataAccess.Models.Category;

namespace Timon.Business.Services.Statistics;

public class StatisticsService : IStatisticsService<DataAccess.Models.User, DataAccess.Models.Category, DataAccess.Models.MoneyRecord, DataAccess.Models.TimeRecord>
{
    private readonly ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> _timeRecordService;
    private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> _moneyRecordService;
    private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;

    public StatisticsService(ITimeRecordService<DataAccess.Models.TimeRecord, DataAccess.Models.User> timeRecordService,
        IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> moneyRecordService, ICategoryService<Category, DataAccess.Models.User> categoryService)
    {
        _timeRecordService = timeRecordService;
        _moneyRecordService = moneyRecordService;
        _categoryService = categoryService;
    }

    public async Task<IEnumerable<double>> GenerateMoneyRecordsStatistics(DataAccess.Models.User user, DateTime from, DateTime to)
    {
        var moneyRecords = await _moneyRecordService.GetAllUsersMoneyRecords(user);
        var filteredMoneyRecords =  moneyRecords.Select(y =>(double)y.Amount);
        return filteredMoneyRecords.ToList();
    }

    public async Task<IEnumerable<double>> GenerateTimeRecordsStatistics(DataAccess.Models.User user, DateTime from, DateTime to)
    {
        var timeRecords = (await _timeRecordService.GetAllUsersTimeRecords(user)).ToList();
        var filteredTimeRecords = timeRecords.Select(y => (y.DateTo - y.DateFrom)).ToList();
        var timeRecordsStatistics = filteredTimeRecords.Select(x => x.TotalMinutes);
        return timeRecordsStatistics.ToList();
    }

    public async Task<Dictionary<Category, double>> GenerateCategoriesStatistics(DataAccess.Models.User user, DateTime from, DateTime to)
    {
        var categories = await _categoryService.GetAllUsersCategories(user);
        var moneyRecords = await _moneyRecordService.GetAllUsersMoneyRecords(user);
        var timeRecords = await _timeRecordService.GetAllUsersTimeRecords(user);
        var categoriesStatistics = categories.ToDictionary(category => category,
            category => (double)(moneyRecords.Count(x=> x.CategoryId == category.Id) + timeRecords.Count(x => x.CategoryId == category.Id)));
        return categoriesStatistics;
    }
}