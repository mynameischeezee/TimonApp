using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Authentication;
using Timon.Abstract.ViewModel;

namespace Timon.Maui.ViewModels.Authentication
{
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string email;


        public RegisterViewModel()
        {
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
