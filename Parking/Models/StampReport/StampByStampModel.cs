using Parking.interfaces;
using Parking.Models.Stamp;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class StampByStampModel
    {
        private IStamp _stamp_service = new StampService();
        private ICompany _company = new CompanyService();

        public string terncode { get; set; }
       
        public string start_date { get; set; }
       
        public string end_date { get; set; }
        
        public string stamp_code { get; set; }
       
        public string status_stamp { get; set; }
       
        public string ternsubcode { get; set; }

        public List<StampByStampList> stamp_by_stamp { get; set; }
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

        public List<stamp_status> stamp_status_list
        {
            get
            {
                return new List<stamp_status> {
                     new stamp_status { status_id = 0, status_name = "Active Stamp" },
                     new stamp_status { status_id = 1 , status_name = "not Active Stamp" },
                     new stamp_status { status_id = 2 , status_name = "Unusual Active Stamp" }

                };
            }
        }
    }
    public class StampByStampList
    {
        
        public string date_time_stamp { get; set; }
        
        public string date_in { get; set; }
        
        public string date_out { get; set; }
        
        public string stamp_code { get; set; }
      
        public string licen_plate { get; set; }
       
        public string visitor_id { get; set; }
        
        public string admin_name { get; set; }
       
        public string amount { get; set; }

    }
}