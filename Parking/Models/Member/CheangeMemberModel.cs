using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class CheangeMemberModel
    {
        public bool check_cheangcontacType { get; set; }
        public bool Check_cheangName { get; set; }
        public bool check_licensep { get; set; }
        
        public string memberCode { get; set; }
     //   public string ternCode { get; set; }
       
        public string cardtype { get; set; }
       
        public string New_Contacttype { get; set; }
       
        public string Contacttype { get; set; }
       // public string sCompanyID { get; set; }
     //   public string sAminname { get; set; }
        public string name { get; set; }
       
        public string lastName { get; set; }
       
        public string payment { get; set; }
        
        public string firstday { get; set; }
     
        public string licenseplate { get; set; }
     
        public string new_licenseplate { get; set; }
  
        public string Model { get; set; }
       
        public string new_Model { get; set; }
      
        public string CarColor { get; set; }
      
        public string new_CarColor { get; set; }
    
        public string licenseplate1 { get; set; }
      
        public string new_licenseplate1 { get; set; }
     
        public string Model1 { get; set; }
       
        public string new_Model1 { get; set; }
     
        public string CarColor1 { get; set; }
      
        public string new_CarColor1 { get; set; }
      
        public string licenseplate2 { get; set; }
       
        public string new_licenseplate2 { get; set; }
       
        public string Model2 { get; set; }
       
        public string new_Model2 { get; set; }
       
        public string CarColor2 { get; set; }
       
        public string new_CarColor2 { get; set; }
       
        public string New_Name { get; set; }
       
        public string New_LastName { get; set; }
       // public string sName { get; set; }

        public List<RequireCarTypeList> GetCardTypeList { get; set; }
        public List<RequireContacttype> ContacttypeList { get; set; }
        public List<Member_List> Member_List { get; set; }
    }

    public class Member_List
    {
        public string MemberID { get; set; }
        public string MemberName { get; set; }
    }
}