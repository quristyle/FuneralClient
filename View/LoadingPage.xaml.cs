
using FuneralClient.ViewModel;

namespace FuneralClient.View;

public partial class LoadingPage : ContentPage {
  LoginViewModel loginViewModel;
  public LoadingPage(LoginViewModel loginViewModel) {
    InitializeComponent();
    this.loginViewModel = loginViewModel;
  }

  protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
    if (await isAuthenticated()) {

      var userid = await SecureStorage.GetAsync("userid");
      var userpw = await SecureStorage.GetAsync("userpw");

      var isLogin = await loginViewModel.IsCredentialCorrect(userid, userpw);
      if (isLogin) {
        await Shell.Current.GoToAsync("///BuildListPage");
      }
      else {
        await Shell.Current.GoToAsync("LoginPage");
      }
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