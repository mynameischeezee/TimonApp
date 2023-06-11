using Timon.Maui.ViewModels.MoneyRecord;

namespace Timon.Maui.Views.MoneyRecord;

public partial class EditMoneyRecordPage : ContentPage
{
    public EditMoneyRecordPage(EditMoneyRecordViewModel moneyRecordViewModel)
    {
        InitializeComponent();
        this.BindingContext = moneyRecordViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as EditMoneyRecordViewModel)?.Update();
    }
}