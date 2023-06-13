using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using Timon.Abstract.Services.Statistics;
using Timon.Abstract.Services.User;
using Timon.Business.Services.Statistics;
using Timon.Business.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Statistics
{
    public partial class StatisticsViewModel : ObservableObject
    {
        private readonly IUserService<User> _userService;

        private readonly IStatisticsService<DataAccess.Models.User,
            DataAccess.Models.Category,
            DataAccess.Models.MoneyRecord,
            DataAccess.Models.TimeRecord> _statisticsService;

        [ObservableProperty] private IEnumerable<ISeries> _categoriesSeries;

        [ObservableProperty] private ISeries[] _moneyRecordsSeries;

        [ObservableProperty] private ISeries[] _timeRecordsSeries;

        public StatisticsViewModel(
            IStatisticsService<User, Category, DataAccess.Models.MoneyRecord, DataAccess.Models.TimeRecord>
                statisticsService, IUserService<User> userService)
        {
            _statisticsService = statisticsService;
            _userService = userService;
            GenerateValues();
        }

        private async void GenerateValues()
        {
            var from = DateTime.Now;
            var to = DateTime.Today.AddDays(-30);
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var categoriesStatistics = await _statisticsService.GenerateCategoriesStatistics(user!, from, to);
            var series = new GaugeBuilder()
                .WithOffsetRadius(5)
                .WithLabelsSize(30)
                .WithInnerRadius(20)
                .WithLabelsPosition(PolarLabelsPosition.Start);
            foreach (var category in categoriesStatistics)
            {
                series.AddValue(new ObservableValue(category.Value), category.Key.Name);
            }

            CategoriesSeries = series.BuildSeries();

            var moneyRecordsStatistics = (await _statisticsService.GenerateMoneyRecordsStatistics(user!, from, to)).ToList();
            MoneyRecordsSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = moneyRecordsStatistics,
                    Fill = null
                }
            };

            var timeRecordsStatistics = (await _statisticsService.GenerateTimeRecordsStatistics(user!, from, to)).ToList();
            TimeRecordsSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = timeRecordsStatistics,
                    Fill = null
                }
            };

        }
        
    }
}
