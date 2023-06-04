using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Timon.Maui.ViewModels.Main
{
    public partial class ShellViewModel : ObservableObject
    {
        public ShellViewModel()
        {

        }

        [RelayCommand]
        private async void SignOut()
        {
            await Shell.Current.GoToAsync("Authentication/login");
        }
    }
}
