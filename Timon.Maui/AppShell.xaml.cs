using Timon.Business.Auth0;
using Timon.Maui.ViewModels.Main;

namespace Timon.Maui;

public partial class AppShell : Shell
{
    public AppShell(Auth0Client auth0Client)
    {
        InitializeComponent();
        this.BindingContext = new ShellViewModel(auth0Client);
    }
}