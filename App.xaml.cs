using FuneralClient.View;

namespace FuneralClient {
  public partial class App : Application {
    public App() {
      InitializeComponent();

      //MainPage = new AppShell();
      
      //MainPage = new LoginPage()
    }


    protected override Window CreateWindow(IActivationState activationState) =>
        new Window(new AppShell()) {
          Width = 400,
          Height = 800,
          X = 100,
          Y = 100
        };



    public const string BaseUrl = @"https://funeralfr.jsini.co.kr";
  }
}
