using CommunityToolkit.Mvvm.Messaging;
using FuneralClient.Model;
using FuneralClient.ViewModel;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace FuneralClient;

public partial class BuildListPage : ContentPage {
  public BuildListPage(BuildViewModel buildViewModel) {
    InitializeComponent();
    this.BindingContext = buildViewModel;


    //WeakReferenceMessenger.Default.Register<MessageModel>(this, (r, m) =>
    //{
    //    // do something, reload view 

    //    string bbbbbbbbbb = "";

    //});


  }




  private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e) {


    Debug.WriteLine("call selectChange");

    Build build = e.CurrentSelection.FirstOrDefault() as Build;

    var navigationParameter = new Dictionary<string, object>
    {
        //{ "SelBuild", new Build(){B_key="99" } }
        { "SelBuild", build }
    };

    await Shell.Current.GoToAsync($"RoomMonitorPage", navigationParameter);

  }

  private void ContentPage_Loaded(object sender, EventArgs e) {
    (this.BindingContext as BuildViewModel).GetBuildsCommand.Execute(this);
  }

  private void Button_Clicked(object sender, EventArgs e) {
    (this.BindingContext as BuildViewModel).GetBuildsCommand.Execute(this);

  }
}

