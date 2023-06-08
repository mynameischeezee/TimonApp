using Timon.Maui.ViewModels.MoneyRecord;

namespace Timon.Maui.Views.MoneyRecord;

public partial class AddMoneyRecordPage : ContentPage
{
	public AddMoneyRecordPage(AddMoneyRecordViewModel addMoneyRecordViewModel)
	{
		InitializeComponent();
        this.BindingContext = addMoneyRecordViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as AddMoneyRecordViewModel)?.Update();
    }
}