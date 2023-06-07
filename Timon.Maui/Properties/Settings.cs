namespace Timon.Maui.Properties;

public static class Settings
{
    public static bool FirstRun
    {
        get => Preferences.Get(nameof(FirstRun), true);
        set => Preferences.Set(nameof(FirstRun), value);
        
    }
}