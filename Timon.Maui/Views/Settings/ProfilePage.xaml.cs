using Timon.Maui.ViewModels.Settings;

namespace Timon.Maui.Views.Settings;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel profileViewModel)
    {
        InitializeComponent();
        this.BindingContext = profileViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ProfileViewModel)?.Update();
    }
}