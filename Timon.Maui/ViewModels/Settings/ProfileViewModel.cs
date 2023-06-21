using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Settings
{
    public partial class ProfileViewModel : ObservableValidator
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _userPicture;

        [ObservableProperty]
        private string _userJoinedDate;

        [ObservableProperty]
        private string _monobankApiKey;

        private readonly IUserService<User> _userService;

        public ProfileViewModel(IUserService<User> userService)
        {
            _userService = userService;
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            UserPicture = CurrentSession.CurrentUserPic!;
            UserName = CurrentSession.CurrentUserNickname!;
            UserJoinedDate = user!.CreatedAt.ToShortDateString();
            MonobankApiKey = user.MonoBankApiKey!;
        }

        [RelayCommand]
        private async void SaveProfile()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            user.UserName = UserName;
            user.MonoBankApiKey = MonobankApiKey;
            await _userService.UpdateUser(user);
        }
    }
}
