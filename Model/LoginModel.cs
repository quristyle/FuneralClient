using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.Model {
  public class LoginModel : BaseModel {
    public string user_email { get; set; }
    public string code { get; set; }
    public string fg_seq { get; set; }
    public string user_nm { get; set; }
    public string page_tab_view { get; set; }
    public string machine_mng { get; set; }
    public string del_yn { get; set; }
    public string mail_cert_yn { get; set; }
    public string b_nm { get; set; }
    public string rols { get; set; }
    public string b_key { get; set; }
    public string isadmin { get; set; }
    public string user_pic { get; set; }
    public string user_id { get; set; }
    public string c_nm { get; set; }
    public string login_dt { get; set; }
    public string c_key { get; set; }
    public string rol_types { get; set; }
    public string last_login_dt { get; set; }
    public string desc { get; set; }
  }
}






