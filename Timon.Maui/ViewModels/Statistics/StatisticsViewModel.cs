using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Statistics;

namespace Timon.Maui.ViewModels.Statistics
{
    public partial class StatisticsViewModel : ObservableObject
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
    }
}
