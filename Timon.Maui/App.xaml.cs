using Timon.Business.Auth0;

namespace Timon.Maui;

public partial class App : Application
{
    public App(Auth0Client auth0Client)
    {
        InitializeComponent();
        MainPage = new AppShell(auth0Client);
    }
}