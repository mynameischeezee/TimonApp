using Timon.Maui.ViewModels.Recommendations;
using Timon.Maui.Views.Authentication;
using Timon.Maui.Views.Categories;
using Timon.Maui.Views.MoneyRecord;
using Timon.Maui.Views.Recommendations;
using Timon.Maui.Views.Settings;
using Timon.Maui.Views.Statistics;
using Timon.Maui.Views.TimeRecord;

namespace Timon.Maui.Extensions
{
    public static class RegisterNavigationRoutes
    {
        public static void Register()
        {
            Routing.RegisterRoute("Authentication/login", typeof(LoginPage));
            Routing.RegisterRoute("MoneyRecord/addMoneyRecord", typeof(AddMoneyRecordPage));
            Routing.RegisterRoute("MoneyRecord/editMoneyRecord", typeof(EditMoneyRecordPage));
            Routing.RegisterRoute("MoneyRecord/moneyRecords", typeof(MoneyRecordsPage));
            Routing.RegisterRoute("Settings/profile", typeof(ProfilePage));
            Routing.RegisterRoute("Settings/settings", typeof(SettingsPage));
            Routing.RegisterRoute("Statistics/statistics", typeof(StatisticsPage));
            Routing.RegisterRoute("TimeRecord/addTimeRecord", typeof(AddTimeRecordPage));
            Routing.RegisterRoute("TimeRecord/editTimeRecord", typeof(EditTimeRecordPage));
            Routing.RegisterRoute("TimeRecord/timeRecords", typeof(TimeRecordsPage));
            Routing.RegisterRoute("Categories/addCategory", typeof(AddCategoryPage));
            Routing.RegisterRoute("Recommendations/generateRecommendation", typeof(RecommendationsPage));
        }

    }
}
