
using FuneralClient.Model;
using FuneralClient.View;

namespace FuneralClient {
  public partial class App : Application {
    public App() {
      InitializeComponent();

      MainPage = new AppShell();

      //MainPage = new LoginPage()


#if WINDOWS
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var nativeWindow = handler.PlatformView;
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            //var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            //appWindow.MoveAndResize(new Windows.Graphics.RectInt32(500, 500, 1000, 1000)); // Can also be used to size and move the current window

            var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(windowId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);

            if (view is Window window)
                ResizeWindow(window, displayArea.WorkArea.Width, displayArea.WorkArea.Height);
        });
#endif

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


    //protected override Window CreateWindow_xxxxxxxxx(IActivationState activationState) {
    protected Window CreateWindow_xxxxxxxxx(IActivationState activationState) {


      var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

      var w = 400;
      var h = 900;

      // Center the window
      var x = (displayInfo.Width / displayInfo.Density - w) / 2;
      var y = (displayInfo.Height / displayInfo.Density - h) / 2;


      // right, bottom the window
      x = (displayInfo.Width / displayInfo.Density - w );
      y = (displayInfo.Height / displayInfo.Density - h );

      DeviceDisplay.Current.KeepScreenOn = true;

#if WINDOWS
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var nativeWindow = handler.PlatformView;
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            //var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            //appWindow.MoveAndResize(new Windows.Graphics.RectInt32(500, 500, 1000, 1000)); // Can also be used to size and move the current window

            var displayArea = Microsoft.UI.Windowing.DisplayArea.GetFromWindowId(windowId, Microsoft.UI.Windowing.DisplayAreaFallback.Nearest);

            if (view is Window window)
                ResizeWindow(window, displayArea.WorkArea.Width, displayArea.WorkArea.Height);
        });
#endif


     //var screens = System.Windows.Forms.Screen.AllScreens;

      //x = -410; y = 600;


      //base.CreateWindow()

      

      var win = new Window(new AppShell()) {
        Width = w,
        Height = h,
        X = x,
        Y = y
      };
      return win; 
      
    }


    private static void ResizeWindow(Window window, int monitorWidth, int monitorHeight) {
      window.Width = 450;
      window.Height = 800;

      var displayDensity = 1;
      var gap = 0;

      // Center
      //window.X = (monitorWidth / displayDensity - window.Width) / 2;
      //window.Y = (monitorHeight / displayDensity - window.Height) / 2;


      // Right bottom
      //window.X = (monitorWidth / displayDensity - window.Width) / 2;
      window.X = (monitorWidth - window.Width - gap) ;
      window.Y = ( monitorHeight - window.Height - gap );
    }


    public const string BaseUrl = @"https://funeralfr.jsini.co.kr";
    public static LoginModel LoginInfo { get; set; }
    public static List<CodeModel> MovieList { get; set; }
    public static List<CodeModel> MusicList { get; set; }
    public static List<CodeModel> ShowTypeList { get; set; }
  }
}
