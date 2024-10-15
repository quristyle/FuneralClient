using FuneralClient.ViewModel;

namespace FuneralClient.View;

public partial class RoomDetailPage : ContentPage {
	public RoomDetailPage(RoomDetailViewModel roomDetailViewModel) {
		InitializeComponent();
		this.BindingContext = roomDetailViewModel;
	}
}