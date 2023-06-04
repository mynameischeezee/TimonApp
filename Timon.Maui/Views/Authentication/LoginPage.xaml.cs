
using Timon.Maui.ViewModels.Authentication;

namespace Timon.Maui.Views.Authentication;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginViewModel;
    }

}