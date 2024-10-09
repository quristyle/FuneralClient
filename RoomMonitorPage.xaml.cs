using FuneralClient.ViewModel;

namespace FuneralClient;

public partial class RoomMonitorPage : ContentPage {
	public RoomMonitorPage(RoomViewModel roomViewModel ) {
		InitializeComponent();
		
        this.BindingContext = roomViewModel;
    }


    private void Button_Clicked(object sender, EventArgs e) {
    }
}