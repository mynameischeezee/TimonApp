using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Timon.Maui.Extensions;
using Timon.Maui.Platforms.Android;


namespace Timon.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
#if ANDROID && DEBUG
        StaticHelper.Register();
#endif
        var builder = MauiApp.CreateBuilder();
        builder
            .UseLocalNotification()
            .UseSkiaSharp(true)
            .UseMauiCommunityToolkit()
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