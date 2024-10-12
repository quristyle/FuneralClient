namespace FuneralClient.View;

public partial class SettingPage : ContentPage {
  public SettingPage() {
    InitializeComponent();

    this.BindingContext = App.LoginInfo;
  }
  private async void LogoutButton_Clicked(object sender, EventArgs e) {
    if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No")) {
      SecureStorage.RemoveAll();
      await Shell.Current.GoToAsync("///LoginPage");
    }
  }

}