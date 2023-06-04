using Microsoft.Extensions.Logging;
using Timon.Maui.Extensions;
using Timon.Maui.ViewModels.Authentication;
using Timon.Maui.ViewModels.MoneyRecord;
using Timon.Maui.ViewModels.Settings;
using Timon.Maui.ViewModels.TimeRecord;
using Timon.Maui.Views.Authentication;
using Timon.Maui.Views.MoneyRecord;
using Timon.Maui.Views.Settings;
using Timon.Maui.Views.TimeRecord;

namespace Timon.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterFonts();
            

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder
            .RegisterAppServices()
            .RegisterViews()
            .RegisterViewModels();
        RegisterNavigationRoutes.Register();
        return builder.Build();
    }
}