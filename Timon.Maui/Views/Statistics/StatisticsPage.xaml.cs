using Timon.Maui.ViewModels.Statistics;

namespace Timon.Maui.Views.Statistics;

public partial class StatisticsPage : ContentPage
{
    public StatisticsPage(StatisticsViewModel statisticsViewModel)
    {
        InitializeComponent();
        this.BindingContext = statisticsViewModel;
    }
}