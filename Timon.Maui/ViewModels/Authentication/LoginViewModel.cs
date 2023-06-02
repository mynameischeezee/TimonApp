using System.Windows.Input;
using Timon.Abstract.ViewModel;

namespace Timon.Maui.ViewModels.Authentication
{
    internal class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        public ICommand LoginCommand { get; private set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(); 
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        
        public LoginViewModel()
        {


#if DEBUG
            Username = "cheeze";
            Password = "Pa$s123=";
#endif
        }
    }
};
