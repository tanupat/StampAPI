using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class CancelMemberModel
    {
       
        public string CancelDate { get; set; }
      
       // public string ternCode { get; set; }

        public string payment { get; set; }
        public string No1 { get; set; }
       
        public string cusNo { get; set; }
        //public string sAminname { get; set; }


        public string name { get; set; }
       
        public string last_name { get; set; }
     
        public string card_type { get; set; }
        
        public string ContractType { get; set; }
       
        public string firstday { get; set; }

       // public string admin_name { get; set; }
       
        public string licenplatel { get; set; }
       
        public string model { get; set; }
       
        public string car_color { get; set; }

      
        public string licenplatel1 { get; set; }
        
        public string model1 { get; set; }
       
        public string car_color1 { get; set; }

       
        public string licenplatel2 { get; set; }
   
        public string model2 { get; set; }
     
        public string car_color2 { get; set; }

        public List<RequireCarTypeList> GetCardTypeList { get; set; }
        public List<Member_List> Member_List { get; set; }
    }
}