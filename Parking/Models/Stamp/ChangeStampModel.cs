using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Stamp
{
    public class ChangeStampModel
    {
        public string inoutTrainStampID { get; set; }
        public string inoutTranID { get; set; }    
        public DateTime DateTimeStamp { get; set; }     
        public string VisitorId { get; set; }
        public string licensePlate { get; set; }
        public string stampCode { get; set; }
        public List<stampCodeList> stampCodeList { get; set; }
        public string stampCodeOld { get; set; }
        //public string sCompanyID { get; set; }
        //public string sDeptID { get; set; }
        //public string sAdminLevel { get; set; }
        //public string sAminname { get; set; }
        //public string sName { get; set; }

    }
}