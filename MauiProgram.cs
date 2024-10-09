using FuneralClient.Services;
using FuneralClient.ViewModel;
using Microsoft.Extensions.Logging;

namespace FuneralClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            builder.Services.AddSingleton<RoomService>();
            builder.Services.AddSingleton<RoomViewModel>();
            builder.Services.AddSingleton<RoomMonitorPage>();




            return builder.Build();
        }
    }
}
