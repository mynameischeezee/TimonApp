﻿using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Timon.Maui.Extensions;

namespace Timon.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseSkiaSharp(true)
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