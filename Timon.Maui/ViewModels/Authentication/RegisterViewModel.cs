using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Authentication;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authenticationService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _email;


        public RegisterViewModel(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
#if DEBUG
            Username = "cheeze";
            Email = "testmail@gmail.com";
            Password = "Pa$s123=";
#endif
        }

        [RelayCommand]
        private async void NavigateToLogin()
        {
            await Shell.Current.GoToAsync("Authentication/login");
        }
    }
}
