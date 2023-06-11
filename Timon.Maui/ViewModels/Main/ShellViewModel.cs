using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Business.Auth0;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Main
{
    public partial class ShellViewModel : ObservableObject
    {
        private readonly Auth0Client _auth0Client;
        public ShellViewModel(Auth0Client auth0Client)
        {
            _auth0Client = auth0Client;
        }

        [RelayCommand]
        private async void SignOut()
        {
            var logoutResult = await _auth0Client.LogoutAsync();
            if (logoutResult.IsError) return;
            CurrentSession.CurrentUserNickname = null;
            await Shell.Current.GoToAsync("Authentication/login");
        }
    }
}
