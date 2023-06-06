using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Authentication;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthenticationService<User> authenticationService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        public LoginViewModel(IAuthenticationService<User> authenticationService)
        {
            this.authenticationService = authenticationService;
#if DEBUG
            Username = "cheeze";
            Password = "Pa$s123=";
#endif
        }

        [RelayCommand]
        private async void NavigateToRegister()
        {
            await Shell.Current.GoToAsync("Authentication/register");
        }

        [RelayCommand]
        private async void Login()
        {
            await Shell.Current.GoToAsync("MoneyRecord/moneyRecords");
        }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }
};
