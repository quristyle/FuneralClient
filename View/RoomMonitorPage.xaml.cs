using FuneralClient.Model;
using FuneralClient.ViewModel;

namespace FuneralClient.View;



public partial class RoomMonitorPage : ContentPage {


  public RoomMonitorPage(RoomViewModel roomViewModel) {
    InitializeComponent();

    this.BindingContext = roomViewModel;
  }


}