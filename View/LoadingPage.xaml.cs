namespace FuneralClient.View;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

  protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
    if (await isAuthenticated()) {
      await Shell.Current.GoToAsync("///BuildListPage");
    }
    else {
      await Shell.Current.GoToAsync("LoginPage");
    }
    base.OnNavigatedTo(args);
  }

  async Task<bool> isAuthenticated() {
    await Task.Delay(2000);
    var hasAuth = await SecureStorage.GetAsync("hasAuth");
    return !(hasAuth == null);
  }

}