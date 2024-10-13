using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using FuneralClient.Model;
using FuneralClient.ViewModel;

namespace FuneralClient.View;



public partial class RoomMonitorPage : ContentPage {
  //RoomViewModel roomViewModel;

  public RoomMonitorPage(RoomViewModel roomViewModel) {
    InitializeComponent();

    this.BindingContext = roomViewModel;
    //this.roomViewModel = roomViewModel;
  }


  protected async override void OnAppearing() {
    base.OnAppearing();
    await Task.Delay(50);


    //foreach (var m in viewModel.Milestones) {
    //  m.SelectedCategory = viewModel.Categories.FirstOrDefault(c => c.IdCategory == m.IdCategory);
    //}
  }

  private void Button_Clicked(object sender, EventArgs e) {

    (this.BindingContext as RoomViewModel).test();

    

  }

  private void Button_Clicked_1(object sender, EventArgs e) {
    var selectRoom = (sender as Button).BindingContext as RoomModel;

    string aa = "";

    // 여기서 영상 리스트를 보여 주자.


  }

  private void Music_Clicked(object sender, EventArgs e) {

  }
}