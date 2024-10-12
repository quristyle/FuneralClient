using CommunityToolkit.Mvvm.Input;
using FuneralClient.Services;
using System.Diagnostics;

namespace FuneralClient.ViewModel {
  public partial class LoginViewModel : BaseViewModel {


    LoginService loginService;

    public LoginViewModel(LoginService loginService) {
      Title = "Room Checked";
      this.loginService = loginService;
    }


   public async Task<bool> IsLoginCheckAsync(string username, string password) {
      var login_result = await loginService.IsLogin(username, password);

      Debug.WriteLine("login result : {0}", login_result);

      return login_result;

      //Shell.Current.CurrentPage.


      //await Shell.Current.GoToAsync($"{nameof(BuildListPage)}");
      

    }


    //var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
    //request.Headers.Add(@"Cookie", @"userid=quristyle, usernm=lee");


  }
}
