using FuneralClient.View;

namespace FuneralClient {
  public partial class App : Application {
    public App() {
      InitializeComponent();

      MainPage = new AppShell();
      //MainPage = new LoginPage()
    }

    public const string BaseUrl = @"https://funeralfr.jsini.co.kr";
  }
}
