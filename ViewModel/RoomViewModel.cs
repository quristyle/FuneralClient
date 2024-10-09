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

namespace FuneralClient.ViewModel
{
    public partial class RoomViewModel: BaseViewModel {

        RoomService roomService;

        public ObservableCollection<Room> Rooms { get; } = new();



        public RoomViewModel(RoomService roomService) {
            Title = "Room Checked";
            this.roomService = roomService;      
        }

        [RelayCommand]
        async Task GetRoomsAsync() {
            if (IsBusy) return;


            try {
                IsBusy = true;
                var rooms = await roomService.GetRooms();

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
