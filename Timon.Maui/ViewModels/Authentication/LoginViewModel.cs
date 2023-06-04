using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Authentication;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthenticationService authenticationService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        public LoginViewModel(IAuthenticationService authenticationService)
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
            authenticationService.Login(username: Username, password: Password);
            await Shell.Current.GoToAsync("MoneyRecord/moneyRecords");
        }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }
};
