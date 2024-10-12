using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FuneralClient.Services {
  public class RoomService : BaseService {

    public RoomService() : base() {
    }

    List<Room> roomList = new();
    public async Task<List<Room>> GetRooms(Build build) {

      if (HttpCnt.BaseAddress == null) {
        HttpCnt.BaseAddress = new Uri($"https://funeralfr.jsini.co.kr");
      }

      var content = new FormUrlEncodedContent(new[]
   {
            new KeyValuePair<string, string>("TBL_DATA", "[{\"b_key\":\""+build.B_key+"\"}]"),
            new KeyValuePair<string, string>("p", "fr.room.roomstatus")
        });


      var response = await HttpCnt.PostAsync("/fr3.jsp", content);


      if (response.StatusCode == System.Net.HttpStatusCode.OK) {
        string resultContent = await response.Content.ReadAsStringAsync();


        Debug.WriteLine("resultContent : {}", resultContent);


        JObject json = JObject.Parse(resultContent);

        //json.SelectToken("$..data")

        //roomList = await response.Content.ReadFromJsonAsync<List<Room>>();


        //roomList = await response.Content.ReadFromJsonAsync<List<Room>>();


        //roomList = (json["data"] as JArray).ToObject<List<FuneralClient.Model.Room>>();

        roomList = (json["data"] as JArray).ToObject<List<FuneralClient.Model.Room>>();

        Debug.WriteLine("resultContent2 : {}", resultContent);


      }
      else {

      }
      Debug.WriteLine("{0}", response.StatusCode);




      //var dataAsString = JsonSerializer.Serialize(data);
      //var dataAsString = "TBL_DATA: [{\"b_key\":\"3\"}]";
      //var content = new StringContent(dataAsString);
      //content.

      //var response = await httpClient.PostAsync(url, content);


      /*
      //var response = await httpClient.GetAsync(url); ;

      if (response.IsSuccessStatusCode) {
          roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
      }

      */

      return roomList;
    }
  }
}