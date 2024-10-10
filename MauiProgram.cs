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





                  fonts.AddFont("FontAwesome6Free-Solid-900.otf", "FaSolid");
                  fonts.AddFont("FontAwesomeFree-Regular-400.otf", "FaRegular");


                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            builder.Services.AddSingleton<RoomService>();
            builder.Services.AddSingleton<RoomViewModel>();
            builder.Services.AddSingleton<RoomMonitorPage>();


            builder.Services.AddSingleton<BuildService>();
            builder.Services.AddSingleton<BuildViewModel>();
            builder.Services.AddSingleton<BuildListPage>();




            return builder.Build();
        }
    }
}
