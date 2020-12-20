using Parking.interfaces;
using Parking.Models.Stamp;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class StampByUserModel
    {
        private IStamp _stamp_service = new StampService();
        private ICompany _company = new CompanyService();
        public string terncode { get; set; }     
        public string ternsubcode { get; set; }
        public string admin_level { get; set; }       
        public string admin_name { get; set; }      
        public string start_date { get; set; }     
        public string end_date { get; set; }    
        public string stamp_code { get; set; }
        public string user_name { get; set; }
        public List<StampByUserTran> StampByUserList { get; set; }

        public List<stampCodeList> stamp_code_list
        {
            get
            {
                List<stampCodeList> list = new List<stampCodeList>();
                list = this._stamp_service.stamp_code_all(this.terncode);
                return list;
            }
        }

        public List<CompanyModel> department_list
        {
            get
            {
                List<CompanyModel> list_company = new List<CompanyModel>();
                list_company = this._company.CheckLevelCompany(this.terncode);
                return list_company;
            }
        }

        public List<AdminModel> admin_list
        {
            get
            {
                List<AdminModel> list = new List<AdminModel>();
                list = _stamp_service.admin_list(this.terncode, this.admin_level);
                return list;
            }
        }


    }
    public class StampByUserTran
    {
       
        public string date_time_stamp { get; set; }
       
        public string stamp_code { get; set; }
       
        public string license_plate { get; set; }
       
        public string visitor_id { get; set; }
       
        public string amount { get; set; }
       
        public string admin_name { get; set; }
    }
}