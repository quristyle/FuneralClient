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

    [RelayCommand]
    async Task AppearingAsync() {
      await GetBuildsAsync();
    }

    //    await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

    [RelayCommand]
    async Task GetBuildsAsync() {

      Debug.WriteLine($"GetBuildsAsync1 {IsBusy}");
      if (IsBusy) return;

      Debug.WriteLine($"GetBuildsAsync2 {IsBusy}");

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




    [RelayCommand]
    void SelectionChanged(BuildModel build) { //BuildModel build


      Debug.WriteLine($"call SelectionChanged Command : {build}");

      //BuildModel build = e.CurrentSelection.FirstOrDefault() as BuildModel;

      var navigationParameter = new Dictionary<string, object>      {
        { "SelBuild", build }
      };

      Shell.Current.GoToAsync($"RoomMonitorPage", navigationParameter);

    }









  }
}