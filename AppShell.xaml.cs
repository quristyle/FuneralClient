using FuneralClient.View;
using System.Runtime.CompilerServices;

namespace FuneralClient {
  public partial class AppShell : Shell {
    public AppShell() {
      InitializeComponent();


      // 황당하게 xaml 에 라우터 등록되거 또 등록 되면... gotosync 동작시 에러 방생함.

      //Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
      //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
      Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
      //Routing.RegisterRoute(nameof(BuildListPage), typeof(BuildListPage));
      Routing.RegisterRoute(nameof(RoomMonitorPage), typeof(RoomMonitorPage));
      Routing.RegisterRoute(nameof(RoomDetailPage), typeof(RoomDetailPage));

    }
  }
}
