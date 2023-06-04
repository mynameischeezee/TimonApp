using Timon.Maui.ViewModels.Authentication;

namespace Timon.Maui.Views.Authentication;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		this.BindingContext = registerViewModel;
	}
}