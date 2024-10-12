using FuneralClient.ViewModel;
using System.Text.Json.Nodes;
namespace FuneralClient.View;
public partial class LoginPage : ContentPage {
  public LoginPage(LoginViewModel loginViewModel) {
    InitializeComponent();
    this.BindingContext = loginViewModel;
  }

  private async void Button_Clicked(object sender, EventArgs e) {

    string uid = txtId.Text;
    string pwd = txtPassword.Text;
    var isLogin = await IsCredentialCorrect(uid, pwd);

    string aaa = "";
    
    if (isLogin == true) {
      await SecureStorage.SetAsync("hasAuth", "true");
      await SecureStorage.SetAsync("userid", uid);
      await SecureStorage.SetAsync("userpw", pwd);
      await Shell.Current.GoToAsync("///BuildListPage");
    }
    else {
      await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
    }
    

  }

  async Task<bool> IsCredentialCorrect(string username, string password) {

    JsonObject jobj = await (this.BindingContext as LoginViewModel).IsLoginCheckAsync(username, password);




    //JsonObject jobj = jnod.AsObject();
    int code = int.Parse(jobj["info"]["code"].ToString());
    string desc = jobj["info"]["desc"].ToString();

    bool result = false;
    if (code < 0) {
      result = false;
    }
    else {
      result = true;
    }


    return result;// login_result.Result.ToString();

    //return txtId.Text == "admin" && txtPassword.Text == "1234";
  }



  /*
  private void Button_Clicked(object sender, EventArgs e) {
    String id = txtId.ToString();
    String pa = txtPassword.ToString();
    Add_Login(id, pa);

    if (txtId.Text == "" || txtPassword.Text == "") {
      DisplayAlert("???", "The ID or Password contains spaces.", "OK");
    }

    else if (txtId.Text == "abcd" && txtPassword.Text == "1234") {
      Navigation.PushAsync(new Page1());
      DisplayAlert("Welcome", "Login Successful!", "OK");

    }

    else if (txtId.Text == "hijk" && txtPassword.Text == "0000") {
      Navigation.PushAsync(new Page1());
      DisplayAlert("Welcome", "Login Successful!", "OK");

    }

    else {
      DisplayAlert("Sorry", "Login Failed!", "OK");
    }
  }

  private void Add_Login(string id, string pws) {
    Dictionary<string, string> datal = new Dictionary<string, string>()
    {
            {"ID", txtId.Text},
            {"Password", txtPassword.Text}
        };
    ADMIN.SetAsync(datal);
  }

  */
}