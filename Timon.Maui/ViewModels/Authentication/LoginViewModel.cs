using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Business.Auth0;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly Auth0Client _auth0Client;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        public LoginViewModel(Auth0Client auth0Client)
        {
            _auth0Client = auth0Client;
#if DEBUG
            Username = "cheeze";
            Password = "Pa$s123=";
#endif
        }

        [RelayCommand]
        private async void Login()
        {
            var loginResult = await _auth0Client.LoginAsync();
            
            if (!loginResult.IsError)
            {
                var nickName = loginResult.User
                    .Claims.FirstOrDefault(c => c.Type == "nickname")?.Value;
                await Shell.Current.GoToAsync("MoneyRecord/moneyRecords");
            }
        }
    }
};
