using FuneralClient.View;
using System.Runtime.CompilerServices;

namespace FuneralClient {
  public partial class AppShell : Shell {
    public AppShell() {
      InitializeComponent();




      //Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
      Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
      Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
      Routing.RegisterRoute(nameof(BuildListPage), typeof(BuildListPage));
      Routing.RegisterRoute(nameof(RoomMonitorPage), typeof(RoomMonitorPage));

    }
  }
}
