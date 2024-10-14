using FuneralClient.Model;
using FuneralClient.View;

namespace FuneralClient {
  public partial class App : Application {
    public App() {
      InitializeComponent();

      //MainPage = new AppShell();
      
      //MainPage = new LoginPage()
    }


    /*
    protected override Window CreateWindow(IActivationState activationState) {
      Window win = base.CreateWindow(activationState);

      win.Page = new AppShell();
      win.Width = 400;

      // Get display size
      var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

      // Center the window
      win.X = (displayInfo.Width / displayInfo.Density - win.Width) / 2;
      win.Y = (displayInfo.Height / displayInfo.Density - win.Height) / 2;

      
      return win;
    }
    */


    protected override Window CreateWindow(IActivationState activationState) {


      var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

      var w = 400;
      var h = 900;

      // Center the window
      var x = (displayInfo.Width / displayInfo.Density - w) / 2;
      var y = (displayInfo.Height / displayInfo.Density - h) / 2;


      // right, bottom the window
      x = (displayInfo.Width / displayInfo.Density - w );
      y = (displayInfo.Height / displayInfo.Density - h );

      x = -410; y = 600;

      var win = new Window(new AppShell()) {
        Width = w,
        Height = h,
        X = x,
        Y = y
      };
      return win; 
    }

    public const string BaseUrl = @"https://funeralfr.jsini.co.kr";
    public static LoginModel LoginInfo { get; set; }
    public static List<CodeModel> MovieList { get; set; }
    public static List<CodeModel> MusicList { get; set; }
    public static List<CodeModel> ShowTypeList { get; set; }
  }
}
