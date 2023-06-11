using Timon.Maui.ViewModels.TimeRecord;

namespace Timon.Maui.Views.TimeRecord;

public partial class EditTimeRecordPage : ContentPage
{
    public EditTimeRecordPage(EditTimeRecordViewModel editTimeRecordViewModel)
    {
        InitializeComponent();
        this.BindingContext = editTimeRecordViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as EditTimeRecordViewModel)?.Update();
    }
}