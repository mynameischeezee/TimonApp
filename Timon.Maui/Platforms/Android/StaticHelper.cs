namespace Timon.Maui.Platforms.Android;

public static class StaticHelper
{
    public static void Register()
    {
        DangerousTrustProvider.Register();
    }
}