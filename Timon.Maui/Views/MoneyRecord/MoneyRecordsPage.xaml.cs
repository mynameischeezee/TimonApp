using Timon.Maui.ViewModels.MoneyRecord;

namespace Timon.Maui.Views.MoneyRecord;

public partial class MoneyRecordsPage : ContentPage
{
    public MoneyRecordsPage(MoneyRecordsViewModel moneyRecordsViewModel)
    {
        InitializeComponent();
        this.BindingContext = moneyRecordsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as MoneyRecordsViewModel)?.Update();
    }
}