using Timon.Maui.Views.Authentication;
using Timon.Maui.Views.Categories;
using Timon.Maui.Views.MoneyRecord;
using Timon.Maui.Views.Recommendations;
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
            builder.Services.AddSingleton<AddMoneyRecordPage>();
            builder.Services.AddSingleton<EditMoneyRecordPage>();
            builder.Services.AddSingleton<MoneyRecordsPage>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<AddTimeRecordPage>();
            builder.Services.AddSingleton<EditTimeRecordPage>();
            builder.Services.AddSingleton<TimeRecordsPage>();
            builder.Services.AddSingleton<StatisticsPage>();
            builder.Services.AddSingleton<AddCategoryPage>();
            builder.Services.AddSingleton<RecommendationsPage>();

            return builder;
        }
    }
}
