using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Settings
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IUserService<User> _userService;

        public ProfileViewModel(IUserService<User> userService)
        {
            _userService = userService;
        }
    }
}
