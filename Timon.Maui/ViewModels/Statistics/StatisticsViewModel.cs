using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.Statistics;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Statistics
{
    public partial class StatisticsViewModel : ObservableObject
    {
        private readonly IStatisticsService<User> _statisticsService;

        public StatisticsViewModel(IStatisticsService<User> statisticsService)
        {
            _statisticsService = statisticsService;
        }
    }
}
