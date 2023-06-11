using Timon.Maui.ViewModels.TimeRecord;

namespace Timon.Maui.Views.TimeRecord;

public partial class AddTimeRecordPage : ContentPage
{
    public AddTimeRecordPage(AddTimeRecordViewModel addTimeRecordViewModel)
    {
        InitializeComponent();
        this.BindingContext = addTimeRecordViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as AddTimeRecordViewModel)?.Update();
    }
}