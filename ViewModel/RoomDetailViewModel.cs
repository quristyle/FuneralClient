using CommunityToolkit.Mvvm.ComponentModel;
using FuneralClient.Model;
using FuneralClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.ViewModel {
  public partial class RoomDetailViewModel : BaseViewModel, IQueryAttributable {

    [ObservableProperty]
    RoomModel selRoom;

    RoomService roomService;


    public RoomDetailViewModel(RoomService roomService) {
      Title = "Room Checked";

      this.roomService = roomService;

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query) {
      SelRoom = query["SelRoom"] as RoomModel;

      var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

      //await Toast.Make("Popup Dismissed By Button").Show();

      //Toast.Make("Popup Dismissed By Button").Show();

    }



  }
}
