
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace FuneralClient.Services {
  public class LoginService : BaseService {
    public LoginService() : base() {

    }


    public async Task<JsonObject> IsLogin(string id, string pws) {


      

      Debug.WriteLine("IsLogin start");
      Debug.WriteLine("IsLogin base url");

      Debug.WriteLine(HttpCnt.BaseAddress.ToString());

      var url = string.Format(@"/loginrst.jsp?lnm={0}&lpw={1}&v="+DateTime.Now.Ticks.ToString(), id, pws);

      var response = await HttpCnt.GetAsync(url);

      string resultContent = "";
      if ( response.StatusCode == System.Net.HttpStatusCode.OK) {
        resultContent = await response.Content.ReadAsStringAsync();
      }
      else {
        resultContent = await response.Content.ReadAsStringAsync();
      }

      // ("/loginrst.jsp?lnm=quristyle&lpw=1") 
      //administrator/8726

      Debug.WriteLine("IsLogin center");
      Debug.WriteLine(resultContent);

      Debug.WriteLine("IsLogin center2");
      //response.StatusCode == System.Net.HttpStatusCode.OK) {
      //string resultContent = await response.Content.ReadAsStringAsync();
      //string result = resultContent.Result;

      Debug.WriteLine("IsLogin end");


      JsonNode jnod = JsonObject.Parse(resultContent);
      JsonObject jobj = jnod.AsObject();

      return jobj;

    }




  }
}
