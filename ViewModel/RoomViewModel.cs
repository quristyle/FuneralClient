using CommunityToolkit.Maui.Alerts;
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


  //[QueryProperty("SelBuild", "SelBuild")]
  //[QueryProperty("SelBuild", "Build")]
  //[IQueryAttributable]
  public partial class RoomViewModel : BaseViewModel, IQueryAttributable {

    [ObservableProperty]
    BuildModel selBuild;

    RoomService roomService;

    public ObservableCollection<RoomModel> Rooms { get; } = new();

    public ObservableCollection<CodeModel> Movies { get; } = new();
    public ObservableCollection<CodeModel> Musics { get; } = new();
    public ObservableCollection<CodeModel> ShowTypes { get; } = new();

    public RoomViewModel(RoomService roomService) {
      Title = "Room Checked";

      foreach (var cdinfo in App.MovieList) {
        Movies.Add(cdinfo);
      }
      foreach (var cdinfo in App.MusicList) {
        Musics.Add(cdinfo);
      }
      foreach (var cdinfo in App.ShowTypeList) {
        ShowTypes.Add(cdinfo);
      }

      this.roomService = roomService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query) {
      SelBuild = query["SelBuild"] as BuildModel;
      await GetRoomsAsync();


      //var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

      //await Toast.Make("Popup Dismissed By Button").Show();
      
      //Toast.Make("Popup Dismissed By Button").Show();





    }

    [RelayCommand]
    async Task GetRoomsAsync() {
      if (IsBusy) return;
      try {
        Rooms.Clear();
        IsBusy = true;
        var rooms = await roomService.GetRooms(SelBuild);
        foreach (var room in rooms) {


          Rooms.Add(room);
        }

        for (int i = 0; i < Rooms.Count; i++){
          var room = Rooms[i];
          foreach (var movie in Movies) {
            if( room.Gi_video == movie.Cd_cd) {
              room.SelectedMovie = movie;
              break;
            }
          }

        }


      }
      catch (Exception ex) {
        await Shell.Current.DisplayAlert("Error!!!!", ex.Message, "OK");
      }
      finally {
        IsBusy = false;
      }
    }



    [RelayCommand]
    async Task GetRoomDetailAsync(RoomModel room) { 

      if (room == null) return;
      Debug.WriteLine($"call ShowRoomDetail Command :{room?.R_nm} => {room}");

      //BuildModel build = e.CurrentSelection.FirstOrDefault() as BuildModel;

      var navigationParameter = new Dictionary<string, object>      {
        { "SelRoom", room }
      };

      await Shell.Current.GoToAsync($"RoomDetailPage", navigationParameter);

    }














  }
}
