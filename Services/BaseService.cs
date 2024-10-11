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

        internal HttpClient httpClient;
        const string baseUrl = @"https://funeralfr.jsini.co.kr";

        public BaseService() {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            login();
            /*
            lnm quristyle
lpw 1
            */


            //var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
            //request.Headers.Add(@"Cookie", @"userid=quristyle, usernm=lee");

        }

        async void login() {
          var response = await httpClient.GetAsync("/loginrst.jsp?lnm=administrator&lpw=4253!!");
            // ("/loginrst.jsp?lnm=quristyle&lpw=1") 

            //administrator/8726

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                string resultContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("logincheck1 :", resultContent);

            }
            else {
                string resultContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("logincheck2 : ", resultContent);

            }

        }


            internal async Task<List<T>> GetDataList<T>(string proc_nm, string tbl_data_str, params string[] prams ) {

            var result = new List<T>();
            var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("p", proc_nm)
                , new KeyValuePair<string, string>("TBL_DATA", tbl_data_str)
                //, new KeyValuePair<string, string>("p", proc_nm)
            }
            );




            var response = await httpClient.PostAsync("/fr3.jsp", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                string resultContent = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(resultContent);

                result = (json["data"] as JArray).ToObject<List<T>>();

            }

            return result;
        }

    }
}
