using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timon.Maui.ViewModels.Authentication;
using Timon.Maui.ViewModels.MoneyRecord;
using Timon.Maui.ViewModels.Settings;
using Timon.Maui.ViewModels.Statistics;
using Timon.Maui.ViewModels.TimeRecord;

namespace Timon.Maui.Extensions
{
    public static class RegisterViewModelsExtension
    {
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<AddMoneyRecordViewModel>();
            builder.Services.AddSingleton<EditMoneyRecordViewModel>();
            builder.Services.AddSingleton<MoneyRecordsViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();
            builder.Services.AddSingleton<ProfileViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<AddTimeRecordViewModel>();
            builder.Services.AddSingleton<EditTimeRecordViewModel>();
            builder.Services.AddSingleton<TimeRecordsViewModel>();
            builder.Services.AddSingleton<StatisticsViewModel>();

            return builder;
        }
    }
}
