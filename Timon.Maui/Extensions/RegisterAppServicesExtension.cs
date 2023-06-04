using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timon.Abstract.Authentication;
using Timon.Business.Authentication;

namespace Timon.Maui.Extensions
{
    public static class RegisterAppServicesExtension
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<ILoginUserService, LoginUserService>();
            builder.Services.AddTransient<IRegisterUserService, RegisterUserService>();

            return builder;
        }
    }
}
