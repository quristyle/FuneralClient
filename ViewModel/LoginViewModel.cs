using CommunityToolkit.Mvvm.Input;
using FuneralClient.Model;
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


    async Task<LoginModel> IsLoginCheckAsync(string username, string password) {
      var jobj = await loginService.IsLogin(username, password);

      return jobj;
    }



    public async Task<bool> IsCredentialCorrect(string username, string password) {

      LoginModel login = await IsLoginCheckAsync(username, password);


      var result = false;

      if( login.code == "0") {
        result = true;
      }

      App.LoginInfo = login;

      return result;

    
    }



  }
}
