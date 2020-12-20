using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Stamp
{
    public class StampModel
    {
       
        public string sCompanyID { get; set; }
        public string sDeptID { get; set; }
        public string sAdminLevel { get; set; }
        public string sAminname { get; set; }
        public string sCustom { get; set; }
        public string user_name { get; set; }

        public string VisitorID { get; set; }
        public DateTime? Time_IN { get; set; }
        public string custom { get; set; }
        public string license_plate { get; set; }
        public List<historyStamp> historyStamp_list { get; set; }
        public List<stampCodeList> StampCodeList { get; set; }
        public string inoutTrainID { get; set; }
        public string TotalTime { get; set; }
        public string StampCodeSelect { get; set; }
        public string PicIn1 { get; set; }
        public string PicIn2 { get; set; }
        public string PicIn3 { get; set; }
    }

    public class InsertStamp {
        public string StampCodeSelect { get; set; }
        public string inoutTrainID { get; set; }
  
        public string custom { get; set; }
      
        
    }


    public class historyStamp
    {

        public DateTime DateTimeStamp { get; set; }
        public string StampCode { get; set; }
        public string Company { get; set; }
        public int? Calculation { get; set; }
        public string ternCode { get; set; }
        public string ternsubCode { get; set; }
        public string InOutTranstamp_ID { get; set; }

    }
    public class stampCodeList
    {
        public string stampcode { get; set; }
        public string stampCodeName { get; set; }
    }
    public class MessageWebModel
    {
        public string Subject1 { get; set; }
        public string Message { get; set; }
        public byte[] pic1 { get; set; }

    }

    public class TranVisitorModel {
        public string InOutTran_ID { get; set; }
        public string CarID { get; set; }
        public string CscMain_ID { get; set; }
        public DateTime Indate { get; set; }
    }


}