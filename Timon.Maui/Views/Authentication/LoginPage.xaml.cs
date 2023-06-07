
using Timon.Maui.ViewModels.Authentication;

namespace Timon.Maui.Views.Authentication;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginViewModel;
    }

    protected override void OnAppearing()
    {
        var lblAnimation = new Animation((value) => { WelcomeLbl.Opacity = value; }, 0, 1);
        WelcomeLbl.Animate("Opacity", lblAnimation, length: 3000);
        base.OnAppearing();
    }
}