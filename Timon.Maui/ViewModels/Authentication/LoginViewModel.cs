using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Services.User;
using Timon.Business.Auth0;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly Auth0Client _auth0Client;
        private readonly IUserService<User> _userService;

        public LoginViewModel(Auth0Client auth0Client, IUserService<User> userService)
        {
            _auth0Client = auth0Client;
            _userService = userService;
        }

        [RelayCommand]
        private async void Login()
        {
            var loginResult = await _auth0Client.LoginAsync();
            if (loginResult.IsError) return;
            var user = new User()
            {
                UserName = loginResult.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value,
                Email = loginResult.User.Claims.First(c => c.Type == "email").Value
            };
            await _userService.CreateUser(user);
            await Shell.Current.GoToAsync("MoneyRecord/moneyRecords");

        }
    }
};
