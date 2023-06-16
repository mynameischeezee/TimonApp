using Microsoft.EntityFrameworkCore;
using MonoBankApi;
using Timon.Abstract.DataAccess.Repository;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.Recommendations;
using Timon.Abstract.Services.Statistics;
using Timon.Abstract.Services.TimeRecord;
using Timon.Abstract.Services.User;
using Timon.Business.Auth0;
using Timon.Business.Services.Categories;
using Timon.Business.Services.MoneyRecord;
using Timon.Business.Services.Recommendations;
using Timon.Business.Services.Statistics;
using Timon.Business.Services.TimeRecord;
using Timon.Business.Services.User;
using Timon.DataAccess.Context;
using Timon.DataAccess.Models;
using Timon.DataAccess.Repository;
using Timon.DataAccess.UnitOfWork;
using Timon.Maui.Properties;

namespace Timon.Maui.Extensions
{
    public static class RegisterAppServicesExtension
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            //TODO: remove sensitive info https://luminousmen.com/post/delete-sensitive-data-from-git/
            builder.Services.AddDbContext<TimonDbContext>(options =>
                { options.UseSqlServer("Server=10.0.2.2,1433;Database=TimonDatabase;User Id=sa;Password=!23jJ0=L3;Persist Security Info=True;TrustServerCertificate=True;"); });
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            builder.Services.AddScoped<IGenericRepository<MoneyRecord>, GenericRepository<MoneyRecord>>();
            builder.Services.AddScoped<IGenericRepository<UserMoneyRecord>, GenericRepository<UserMoneyRecord>>();
            builder.Services.AddScoped<IGenericRepository<TimeRecord>, GenericRepository<TimeRecord>>();
            builder.Services.AddScoped<IGenericRepository<UserTimeRecord>, GenericRepository<UserTimeRecord>>();

            builder.Services.AddScoped<IUserService<User>, UserService>();
            builder.Services.AddScoped<IMoneyRecordService<MoneyRecord, User>, MoneyRecordService>();
            builder.Services.AddScoped<ITimeRecordService<TimeRecord, User>, TimeRecordService>();
            builder.Services.AddScoped<IStatisticsService<User, Category, MoneyRecord, TimeRecord>, StatisticsService>();
            builder.Services.AddScoped<ICategoryService<Category, User>, CategoryService>();
            builder.Services.AddScoped<IRecommendationsService<User>, RecommendationService>();

            builder.Services.AddAutoMapper(typeof(MapConfiguration));
            builder.Services.AddMonoApi("u9gPDp_bhAXMR6Jsk2IFISgzoVq4VtweErqFxW-GM3TY");
            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "dev-xt8s3dz0w2ojvezt.us.auth0.com",
                ClientId = "iXbCzyNO5kY228eJyt67fHVqmOLZPM4f",
                Scope = "openid profile",
                RedirectUri = "myapp://callback"
            }));

            return builder;
        }
    }
}
