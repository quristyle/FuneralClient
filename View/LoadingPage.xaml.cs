using FuneralClient.Services;

namespace FuneralClient.View;

public partial class LoadingPage : ContentPage {
  LoginService loginService;
  public LoadingPage(LoginService loginService) {
    InitializeComponent();
    this.BindingContext = loginService;
  }

  protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
    if (await isAuthenticated()) {

      var userid = await SecureStorage.GetAsync("userid");
      var userpw = await SecureStorage.GetAsync("userpw");

      

      await (this.BindingContext as LoginService).IsLogin(userid,userpw);
      await Shell.Current.GoToAsync("///BuildListPage");
    }
    else {
      await Shell.Current.GoToAsync("LoginPage");
    }
    base.OnNavigatedTo(args);
  }

  async Task<bool> isAuthenticated() {
    await Task.Delay(1000);
    var hasAuth = await SecureStorage.GetAsync("hasAuth");
    return !(hasAuth == null);
  }

}