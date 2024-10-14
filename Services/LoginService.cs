
using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace FuneralClient.Services {
  public class LoginService : BaseService {
    public LoginService() : base() {

    }


    public async Task<LoginModel> IsLogin(string id, string pws) {
      //logout 먼저 처리
      var url = "/logout.jsp";
      var response = await HttpCnt.GetAsync(url);

      //login 처리
      url = string.Format(@"/loginrst.jsp?lnm={0}&lpw={1}&v=" + DateTime.Now.Ticks.ToString(), id, pws);
      response = await HttpCnt.GetAsync(url);
      string resultContent = "";
      if (response.StatusCode == System.Net.HttpStatusCode.OK) {
        resultContent = await response.Content.ReadAsStringAsync();
      }
      else {
        resultContent = await response.Content.ReadAsStringAsync();
      }
      JObject json = JObject.Parse(resultContent);
      LoginModel result = (json["info"] as JObject).ToObject<LoginModel>();
      if( result.code == "0") {
        await LoadCommon();
      }
      return result;
    }


    public async Task LoadCommon() {

      App.MovieList = await GetDataList<CodeModel>("fr.code.list", new Dictionary<string, string>() { { "pcd_seq", "MOVIE" } }, null);
      App.MusicList = await GetDataList<CodeModel>("fr.code.list", new Dictionary<string, string>() { { "pcd_seq", "MUSIC" } }, null);
      App.ShowTypeList = await GetDataList<CodeModel>("fr.code.list", new Dictionary<string, string>() { { "pcd_seq", "GOIN_TP" } }, null);


    }




  }
}
