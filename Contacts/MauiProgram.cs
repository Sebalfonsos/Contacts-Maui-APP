using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;

namespace Contacts
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBottomSheet()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands-400.ttf", "fa-brands-400");
                    fonts.AddFont("fa-duotone-900.ttf", "fa-duotone-900");
                    fonts.AddFont("fa-light-300.ttf", "fa-light-300");
                    fonts.AddFont("fa-regular-400.ttf", "fa-regular-400");
                    fonts.AddFont("fa-sharp-light-300.ttf", "fa-sharp-regular-400");
                    fonts.AddFont("fa-sharp-regular-400.ttf", "fa-sharp-regular-400");
                    fonts.AddFont("fa-sharp-solid-900.ttf", "fa-sharp-solid-900");
                    fonts.AddFont("fa-solid-900.ttf", "fa-solid-900");
                    fonts.AddFont("fa-thin-100.ttf", "fa-thin-100");
                    fonts.AddFont("fa-v4compatibility.ttf", "fa-v4compatibility");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
