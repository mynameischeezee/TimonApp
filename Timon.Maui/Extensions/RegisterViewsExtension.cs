﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timon.Maui.Views.Authentication;
using Timon.Maui.Views.MoneyRecord;
using Timon.Maui.Views.Settings;
using Timon.Maui.Views.Statistics;
using Timon.Maui.Views.TimeRecord;

namespace Timon.Maui.Extensions
{
    public static class RegisterViewsExtension
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<AddMoneyRecordPage>();
            builder.Services.AddSingleton<EditMoneyRecordPage>();
            builder.Services.AddSingleton<MoneyRecordsPage>();
            builder.Services.AddSingleton<AboutPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<AddTimeRecordPage>();
            builder.Services.AddSingleton<EditTimeRecordPage>();
            builder.Services.AddSingleton<TimeRecordsPage>();
            builder.Services.AddSingleton<StatisticsPage>();

            return builder;
        }
    }
}