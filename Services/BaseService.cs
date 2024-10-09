using FuneralClient.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        void login() {
            httpClient.GetAsync("/loginchk.jsp?lnm=quristyle&lpw=1");
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
