using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FuneralClient.Model;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel {
  public partial class BuildViewModel : BaseViewModel {

    BuildService buildService;


    [ObservableProperty]
    bool isRefreshing;

    public ObservableCollection<BuildModel> Builds { get; } = new();

    [ObservableProperty]
    BuildModel selectedBuild;


    public ObservableCollection<CodeModel> Movies { get; } = new();

    public BuildViewModel(BuildService buildService) {
      Title = "BuildViewModel";
      this.buildService = buildService;

      foreach( var cdinfo in App.MovieList) {
        Movies.Add(cdinfo);
      }
    }

    int RefreshDuration = 5;


    [RelayCommand]
    async Task RefreshItemsAsync() {


      Debug.WriteLine("call RefreshItemsAsync start");
      IsRefreshing = true;
      await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

      Debug.WriteLine("call RefreshItemsAsync end");

      IsRefreshing = false;
    }















    [RelayCommand]
    async Task GetBuildsAsync() {
      if (IsBusy) return;


      try {
        IsBusy = true;

        Builds.Clear();
        var builds = await buildService.GetBuilds();

       // if( builds.Count > 0) SelectedBuild = builds[0];

        foreach (var build in builds) {
          Builds.Add(build);
        }

      }
      catch (Exception ex) {
        Debug.WriteLine(ex);
        await Shell.Current.DisplayAlert("Error!!", ex.Message, "OK");
      }
      finally {
        IsBusy = false;
      }

    }


  }
}