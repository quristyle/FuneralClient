using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FuneralClient.Services {
  public class RoomService : BaseService {

    public RoomService() : base() {
    }

    List<RoomModel> roomList = new();
    public async Task<List<RoomModel>> GetRooms(BuildModel build) {
      var dics = new Dictionary<string, string>() {
        { "b_key", build?.B_key}
      };
      roomList = await GetDataList<RoomModel>("fr.room.roomstatus", dics, null);


      return roomList;
    }
  }
}