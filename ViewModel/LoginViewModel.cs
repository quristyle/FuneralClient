using CommunityToolkit.Mvvm.Input;
using FuneralClient.Services;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace FuneralClient.ViewModel {
  public partial class LoginViewModel : BaseViewModel {


    LoginService loginService;

    public LoginViewModel(LoginService loginService) {
      Title = "Room Checked";
      this.loginService = loginService;
    }


   public async Task<JsonObject> IsLoginCheckAsync(string username, string password) {
      var jobj = await loginService.IsLogin(username, password);






      return jobj;

      //Shell.Current.CurrentPage.


      //await Shell.Current.GoToAsync($"{nameof(BuildListPage)}");
      

    }


    //var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
    //request.Headers.Add(@"Cookie", @"userid=quristyle, usernm=lee");


  }
}
