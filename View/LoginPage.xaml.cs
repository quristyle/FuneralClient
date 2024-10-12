using FuneralClient.ViewModel;
namespace FuneralClient.View;
public partial class LoginPage : ContentPage {
  public LoginPage(LoginViewModel loginViewModel) {
    InitializeComponent();
    this.BindingContext = loginViewModel;
  }

  private async void Button_Clicked(object sender, EventArgs e) {

    var isLogin = await IsCredentialCorrect(txtId.Text, txtPassword.Text);

    string aaa = "";
    
    if (isLogin == true) {
      await SecureStorage.SetAsync("hasAuth", "true");
      await Shell.Current.GoToAsync("///BuildListPage");
    }
    else {
      await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
    }
    

  }

  async Task<bool> IsCredentialCorrect(string username, string password) {

    var login_result = await (this.BindingContext as LoginViewModel).IsLoginCheckAsync(username, password);

    return login_result;// login_result.Result.ToString();

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