using Timon.Maui.ViewModels.TimeRecord;

namespace Timon.Maui.Views.TimeRecord;

public partial class TimeRecordsPage : ContentPage
{
    public TimeRecordsPage(TimeRecordsViewModel timeRecordsViewModel)
    {
        InitializeComponent();
        this.BindingContext = timeRecordsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TimeRecordsViewModel)?.Update();
    }
}