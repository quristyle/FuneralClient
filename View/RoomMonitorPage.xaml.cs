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




}