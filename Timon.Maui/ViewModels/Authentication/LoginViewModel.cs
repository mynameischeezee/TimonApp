using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.LocalNotification;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.User;
using Timon.Business.Auth0;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly Auth0Client _auth0Client;
        private readonly IUserService<User> _userService;
        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;

        public LoginViewModel(Auth0Client auth0Client, IUserService<User> userService, IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService)
        {
            _auth0Client = auth0Client;
            _userService = userService;
            _moneyRecordService = moneyRecordService;
        }

        [RelayCommand]
        private async void Login()
        {
            var loginResult = await _auth0Client.LoginAsync();
            if (loginResult.IsError) return;
            var userNickname = loginResult.User.Claims.First(c => c.Type == "nickname").Value;
            var currentUser = await _userService.GetUserByNickname(userNickname);
            if (currentUser == null)
            {
                var user = new User()
                {
                    UserName = userNickname
                };
                await _userService.CreateUser(user);
            }
            CurrentSession.CurrentUserNickname = userNickname;
            CurrentSession.CurrentUserPic = loginResult.User
                .Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
            Application.Current!.MainPage = new AppShell(_auth0Client);
            StartNotificationWork(userNickname);
            
        }

        private async void StartNotificationWork(string userNickname)
        {
            await LocalNotificationCenter.Current.Show(CreateWelcomeNotification(userNickname));
            await LocalNotificationCenter.Current.Show(CreateWelcomeNotification(userNickname));
        }

        private NotificationRequest CreateWelcomeNotification(string nickName)
        {
            var requset = new NotificationRequest()
            {
                NotificationId = 1111,
                Title = "Timon.",
                Subtitle = "Money and budget tracker.",
                Description = "Hey! {nickName}. Thank you for joining to Timon family",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule()
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };
            return requset;
        }

        private NotificationRequest CreateSchedulesNotification(string nickName)
        {
            var requset = new NotificationRequest()
            {
                NotificationId = 1112,
                Title = "Timon.",
                Subtitle = "Money and budget tracker.",
                Description = $"Hey! {nickName}. How is your productivity today?",
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule()
                {
                    NotifyTime = DateTime.Now.AddHours(1),
                    NotifyRepeatInterval = TimeSpan.FromHours(12)
                }
            };
            return requset;
        }
    }
};
