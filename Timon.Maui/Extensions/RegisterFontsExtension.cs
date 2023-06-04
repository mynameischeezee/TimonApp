namespace Timon.Maui.Extensions
{
    public static class RegisterFontsExtension
    {
        public static MauiAppBuilder RegisterFonts(this MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
             {
                 fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                 fonts.AddFont("OpenSans-BoldItalic.ttf", "OpenSansBoldItalic");
                 fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
                 fonts.AddFont("OpenSans-ExtraBoldItalic.ttf", "OpenSansExtraBoldItalic");
                 fonts.AddFont("OpenSans-Italic.ttf", "OpenSansItalic");
                 fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                 fonts.AddFont("OpenSans-LightItalic.ttf", "OpenSansLightItalic");
                 fonts.AddFont("OpenSans-Medium.ttf", "OpenSansMedium");
                 fonts.AddFont("OpenSans-MediumItalic.ttf", "OpenSansMediumItalic");
                 fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                 fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                 fonts.AddFont("OpenSans-SemiBoldItalic.ttf", "OpenSansSemiBoldItalic");
             });

            return builder;
        }
    }
}
