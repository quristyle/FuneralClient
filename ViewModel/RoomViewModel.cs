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


    /*
public Build SelBuild {
  get { return selBuild; }
  set {
    GetRoomsAsync();
  } 
}
    */


    RoomService roomService;




    public ObservableCollection<RoomModel> Rooms { get; } = new();




    public RoomViewModel(RoomService roomService) {
      Title = "Room Checked";
      this.roomService = roomService;
    }



    public void ApplyQueryAttributes(IDictionary<string, object> query) {
      SelBuild = query["SelBuild"] as BuildModel;

      GetRoomsAsync();

      string aaa = "";
    }





    [RelayCommand]
    async Task GetRoomsAsync() {

      Debug.WriteLine("GetRoomsAsync  ");
      Debug.WriteLine("GetRoomsAsync {0} ", "aaa");
      Debug.WriteLine("GetRoomsAsync {0} ", "bbbb", "ccccc");
      Debug.WriteLine("selBuild is null {0} ", (SelBuild is null));

      //return;


      if (IsBusy) return;


      try {
        Rooms.Clear();
        IsBusy = true;
        var rooms = await roomService.GetRooms(SelBuild);
        foreach (var room in rooms) {
          Rooms.Add(room);
        }

      }
      catch (Exception ex) {
        Debug.WriteLine(ex);
        await Shell.Current.DisplayAlert("Error!!!!", ex.Message, "OK");
      }
      finally {
        IsBusy = false;
      }

    }


  }
}
