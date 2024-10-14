using CommunityToolkit.Mvvm.Messaging;
using FuneralClient.Model;
using FuneralClient.ViewModel;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace FuneralClient.View;

public partial class BuildListPage : ContentPage {
  public BuildListPage(BuildViewModel buildViewModel) {
    InitializeComponent();
    this.BindingContext = buildViewModel;
  }
}

