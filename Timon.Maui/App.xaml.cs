using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Timon.Maui.ViewModels.Authentication;
using Timon.Maui.Views.Authentication;

namespace Timon.Maui;

public partial class App : Application
{
    public App(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        MainPage = new LoginPage(loginViewModel);

        LiveCharts.Configure(config =>
            config
                .AddSkiaSharp()
                .AddDefaultMappers()
                .AddDarkTheme()
                .AddLightTheme());
    }
}