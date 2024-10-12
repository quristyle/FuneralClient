using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralClient.Model {

    public class ReqMessage {
        public Result result { get; set; }
        public RoomModel[] data { get; set; }
    }

    public class Result {
        public string excuteRowCnt { get; set; }
        public string code { get; set; }
        public string outputExsit { get; set; }
        public string pstr { get; set; }
        public string detail { get; set; }
        public string exectime { get; set; }
        public Pis pis { get; set; }
        public string desc { get; set; }
        public Pisdata[] pisData { get; set; }
    }

    public class Pis {
        public string b_key { get; set; }
        public object key3 { get; set; }
        public object company { get; set; }
        public object key { get; set; }
    }

    public class Pisdata {
    }

}
