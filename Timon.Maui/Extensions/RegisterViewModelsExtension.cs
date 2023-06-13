using Timon.Maui.ViewModels.Authentication;
using Timon.Maui.ViewModels.Categories;
using Timon.Maui.ViewModels.Main;
using Timon.Maui.ViewModels.MoneyRecord;
using Timon.Maui.ViewModels.Settings;
using Timon.Maui.ViewModels.Statistics;
using Timon.Maui.ViewModels.TimeRecord;
using Timon.Maui.ViewModels.Recommendations;

namespace Timon.Maui.Extensions
{
    public static class RegisterViewModelsExtension
    {
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<ShellViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<AddMoneyRecordViewModel>();
            builder.Services.AddSingleton<EditMoneyRecordViewModel>();
            builder.Services.AddSingleton<MoneyRecordsViewModel>();
            builder.Services.AddSingleton<ProfileViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<AddTimeRecordViewModel>();
            builder.Services.AddSingleton<EditTimeRecordViewModel>();
            builder.Services.AddSingleton<TimeRecordsViewModel>();
            builder.Services.AddSingleton<StatisticsViewModel>();
            builder.Services.AddSingleton<AddCategoryViewModel>();
            builder.Services.AddSingleton<RecommendationViewModel>();
            return builder;
        }
    }
}
