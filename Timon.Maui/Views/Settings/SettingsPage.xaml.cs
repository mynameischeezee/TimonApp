using Timon.Maui.ViewModels.Settings;

namespace Timon.Maui.Views.Settings;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel settingsViewModel)
    {
        InitializeComponent();
        this.BindingContext = settingsViewModel;
    }
}