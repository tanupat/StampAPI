using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class RequireMember
    {
       // public string TernCode { get; set; }     
        public string carType { get; set; }  
        public string Contacttype { get; set; }     
        public string name { get; set; }    
        public string lastName { get; set; }     
        public string payment { get; set; }      
        public string firstday { get; set; }      
        public string licenseplate { get; set; }      
        public string Model { get; set; }    
        public string Color { get; set; }
        public string licenseplate1 { get; set; }
        public string Model1 { get; set; }
        public string Color1 { get; set; }
        public string licenseplate2 { get; set; }
        public string Model2 { get; set; }
        public string Color2 { get; set; }
        public string PhoneNumber { get; set; }
      //  public string sAminname { get; set; }
        public List<RequireCarTypeList> CarTypelist { get; set; }
        public List<RequireContacttype> ContacttypeList { get; set; }
        public List<Requirepayment> paymentList { get; set; }
    }

    public class RequireCarTypeList
    {
        public string CarTypeID { get; set; }
        public string carType { get; set; }
    }

    public class RequireContacttype
    {
        public string contacttypeId { get; set; }
        public string contactype { get; set; }

    }

    public class Requirepayment
    {
        public string paymentId { get; set; }
        public string payment { get; set; }
    }
}