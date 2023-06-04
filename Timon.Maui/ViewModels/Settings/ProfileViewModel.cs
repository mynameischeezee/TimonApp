using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.User;

namespace Timon.Maui.ViewModels.Settings
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
