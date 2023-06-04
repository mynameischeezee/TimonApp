﻿using Microsoft.EntityFrameworkCore;
using MonoBankApi;
using Timon.Abstract.Authentication;
using Timon.Abstract.MoneyRecord;
using Timon.Abstract.Statistics;
using Timon.Abstract.TimeRecord;
using Timon.Abstract.User;
using Timon.Business.Authentication;
using Timon.Business.MoneyRecord;
using Timon.Business.Statistics;
using Timon.Business.TimeRecord;
using Timon.Business.User;
using Timon.DataAccess.Data;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Maui.Extensions
{
    public static class RegisterAppServicesExtension
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddDbContext<TimonDbContext>(options => { options.UseSqlServer("");});
            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IMoneyRecordService, MoneyRecordService>();
            builder.Services.AddTransient<ITimeRecordService, TimeRecordService>();
            builder.Services.AddTransient<IStatisticsService, StatisticsService>();
            builder.Services.AddMonoApi("");

            return builder;
        }
    }
}
