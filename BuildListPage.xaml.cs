using FuneralClient.ViewModel;

namespace FuneralClient;

public partial class BuildListPage : ContentPage {
	public BuildListPage( BuildViewModel buildViewModel) {
		InitializeComponent();
		this.BindingContext = buildViewModel;
	}
}