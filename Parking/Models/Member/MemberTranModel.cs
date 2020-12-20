using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class MemberTranModel
    {
       
        public string startdate { get; set; }

       
        public string end_date { get; set; }

       
        public string CscMain { get; set; }

        public List<MemberList> memberList { get; set; }

        
        public string InOut { get; set; }

        public List<InOutList> inout_list { get; set; }

        
        public string depId { get; set; }

        public List<DepartmentList> DepList { get; set; }

     
        public string CardType { get; set; }

        public List<CardTypeList> CardTypeList { get; set; }

        public List<memberTranList> memberTran { get; set; }
    }
    public class MemberList
    {

        public string csc_main { get; set; }
        public string name { get; set; }
    }

    public class DepartmentList
    {

        public string DepId { get; set; }
        public string DepName { get; set; }
    }

    public class CardTypeList
    {

        public string CardTypeId { get; set; }
        public string CardType { get; set; }
    }

    public class InOutList
    {
        public int inoutId { get; set; }
        public string inout_name { get; set; }
    }

    public class memberTranList
    {

       
        public int no { get; set; }
      
        public string card_number { get; set; }
        
        public string time_in { get; set; }
   
        public string time_out { get; set; }
        
        public string licensePlate { get; set; }
       
        public string name { get; set; }
    }
}