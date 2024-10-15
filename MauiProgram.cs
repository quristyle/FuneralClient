using CommunityToolkit.Maui;
using FuneralClient.Services;
using FuneralClient.View;
using FuneralClient.ViewModel;
using Microsoft.Extensions.Logging;

namespace FuneralClient {
  public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
      var builder = MauiApp.CreateBuilder();
      builder
          .UseMauiApp<App>()
      // Initialize the .NET MAUI Community Toolkit by adding the below line of code
          .UseMauiCommunityToolkit()
          .RegisterAppServices()
          .RegisterViewModels()
          .ConfigureFonts(fonts => {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

            fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerifBold");
            fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
            fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
            fonts.AddFont("Poppins-Regular.ttf", "Poppins");
            fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");

            fonts.AddFont("FontAwesome6Free-Solid-900.otf", "FaSolid");
            fonts.AddFont("FontAwesomeFree-Regular-400.otf", "FaRegular");


          });

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder) {
      builder.Services.AddSingleton<LoginService>();
      builder.Services.AddSingleton<RoomService>();
      builder.Services.AddSingleton<BuildService>();

      return builder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder) {

      builder.Services.AddTransient<LoadingViewModel>();
      builder.Services.AddTransient<LoadingPage>();

      builder.Services.AddTransient<LoginViewModel>();
      builder.Services.AddTransient<LoginPage>();

      builder.Services.AddTransient<RoomViewModel>();
      builder.Services.AddTransient<RoomMonitorPage>();

      builder.Services.AddTransient<BuildViewModel>();
      builder.Services.AddTransient<BuildListPage>();

      return builder;
    }






  }












}


/*
 

## XAML usage

In order to make use of the toolkit within XAML you can use this namespace:

xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"

## Further information

For more information please visit:

- Our documentation site: https://docs.microsoft.com/dotnet/communitytoolkit/maui

- Our GitHub repository: https://github.com/CommunityToolkit/Maui



 */