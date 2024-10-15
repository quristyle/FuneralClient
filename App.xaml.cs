
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
    static List<CodeModel> _movieList { get; set; }
    public static List<CodeModel> MovieList { get {
        if (_movieList == null) _movieList = new();
        return _movieList;
      } 
      set {
        _movieList = value;
      }
    }
    public static List<CodeModel> MusicList { get; set; }
    public static List<CodeModel> ShowTypeList { get; set; }
  }
}
