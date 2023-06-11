using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Timon.Maui.ViewModels.Settings
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isDarkMode;

        [ObservableProperty]
        private bool _isSyncedWithOs;

        [ObservableProperty]
        private bool _canSwitchTheme;

        public SettingsViewModel()
        {
            IsSyncedWithOs = Application.Current.UserAppTheme == AppTheme.Unspecified;
            CanSwitchTheme = !IsSyncedWithOs;
        }

        [RelayCommand]
        private void SwitchAppTheme()
        {
            var appTheme = IsDarkMode ? AppTheme.Dark : AppTheme.Light;
            Application.Current.UserAppTheme = appTheme;
        }

        [RelayCommand]
        private void SwitchAppThemeToSystems()
        {
            CanSwitchTheme = !IsSyncedWithOs;
            IsDarkMode = false;
            Application.Current.UserAppTheme = AppTheme.Unspecified;
        }
    }
}
