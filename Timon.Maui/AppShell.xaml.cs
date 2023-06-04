using Timon.Maui.ViewModels.Main;

namespace Timon.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new ShellViewModel();
    }
}