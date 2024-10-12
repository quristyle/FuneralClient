using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.Services {
  public class BaseService {




    public static HttpClient HttpCnt;

    public BaseService() {
      if (HttpCnt == null || HttpCnt.BaseAddress == null) {
        HttpCnt = new HttpClient();
        HttpCnt.BaseAddress = new Uri(App.BaseUrl);
      }
    }



    internal async Task<List<T>> GetDataList<T>(string proc_nm, string tbl_data_str, params string[] prams) {

      var result = new List<T>();
      var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("p", proc_nm)
                , new KeyValuePair<string, string>("TBL_DATA", tbl_data_str)
                //, new KeyValuePair<string, string>("p", proc_nm)
            }
      );




      var response = await HttpCnt.PostAsync("/fr3.jsp", content);

      if (response.StatusCode == System.Net.HttpStatusCode.OK) {
        string resultContent = await response.Content.ReadAsStringAsync();

        JObject json = JObject.Parse(resultContent);

        result = (json["data"] as JArray).ToObject<List<T>>();

      }

      return result;
    }

  }
}
