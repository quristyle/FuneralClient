using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FuneralClient.Services {
    public class BuildService : BaseService {

        public BuildService():base() {
        }

        public Task<List<BuildModel>> GetBuilds() {
            return GetDataList<BuildModel>("fr.code.list", "[{\"pcd_seq\":\"build\"}]", null);

        }
            public Task<List<RoomModel>> GetRooms() {
            return GetDataList<RoomModel>("fr.room.roomstatus", "[{\"b_key\":\"14\"}]", null);

            /*

            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("TBL_DATA", "[{\"b_key\":\"14\"}]"),
                new KeyValuePair<string, string>("p", "fr.room.roomstatus")
            }
            );

            var response = await httpClient.PostAsync("/fr3.jsp", content);

            if(response.StatusCode == System.Net.HttpStatusCode.OK) {
                string resultContent = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(resultContent);

                roomList = (json["data"] as JArray).ToObject<List<Room>>();

            }
            else {

            }
           
            return roomList;
            */
        }
    }
}