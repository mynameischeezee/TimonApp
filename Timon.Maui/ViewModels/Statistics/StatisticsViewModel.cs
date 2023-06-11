using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using Timon.Abstract.Services.Statistics;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Statistics
{
    public partial class StatisticsViewModel : ObservableObject
    {
        private readonly Random _random = new();

        public StatisticsViewModel()
        {
            ObservableValue1 = new ObservableValue { Value = 50 };
            ObservableValue2 = new ObservableValue { Value = 80 };
            ObservableValue3 = new ObservableValue { Value = 10 };
            ObservableValue4 = new ObservableValue { Value = 90 };

            Series = new GaugeBuilder()
                .WithOffsetRadius(5)
                .WithLabelsPosition(PolarLabelsPosition.Start)
                .AddValue(ObservableValue1, "Procrastination")
                .AddValue(ObservableValue2, "Diploma")
                .AddValue(ObservableValue3, "Food")
                .AddValue(ObservableValue4, "Work")
                .BuildSeries();
        }

        public ObservableValue ObservableValue1 { get; set; }
        public ObservableValue ObservableValue2 { get; set; }
        public ObservableValue ObservableValue3 { get; set; }
        public ObservableValue ObservableValue4 { get; set; }
        public IEnumerable<ISeries> Series { get; set; }

        [RelayCommand]
        public void DoRandomChange()
        {
            ObservableValue1.Value = _random.Next(0, 100);
            ObservableValue2.Value = _random.Next(0, 100);
        }


    }
}
