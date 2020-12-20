using Parking.interfaces;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Stamp;

namespace Parking.Models.StampReport
{
    public class StampByCustomModel
    {
        private IStamp _stamp_service = new StampService();
        private ICompany _company = new CompanyService();

        public string tern_code { get; set; }
        
        public string start_date { get; set; }
      
        public string end_date { get; set; }
        
        public string stamp_code { get; set; }
       
        public string ternsubcode { get; set; }
       
        public string custom { get; set; }
       
        public string in_out { get; set; }
      
        public string stamp_status { get; set; }
     
        public string car_type { get; set; }


        public List<ReportByCustomTran> data_reportByCustom { get; set; }


        public List<stampCodeList> stamp_code_list
        {
            get
            {
                List<stampCodeList> list = new List<stampCodeList>();
                list = this._stamp_service.stamp_code_all(this.tern_code);
                return list;
            }
        }
        public List<CompanyModel> department_list
        {
            get
            {
                List<CompanyModel> list_company = new List<CompanyModel>();
                list_company = this._company.CheckLevelCompany(this.tern_code);
                return list_company;
            }
        }
        public List<CustomModel> custom_list
        {
            get
            {
                List<CustomModel> list = new List<CustomModel>();
                list = this._stamp_service.custom_stamp(this.tern_code, this.ternsubcode);
                return list;
            }
        }

        public List<in_out> in_out_list
        {
            get
            {
                return new List<in_out> {
                     new in_out { in_out_id ="1" , inout = "OUT" },
                     new in_out { in_out_id ="0" , inout = "IN" }
                  };
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


        public List<Car_type> Car_type_list
        {
            get
            {
                return new List<Car_type> {
                    new Car_type { Car_type_code = "C",  Car_type_name = "Car" },
                    new Car_type { Car_type_code = "M", Car_type_name = "motorcycle" }
                };
            }
        }

    }
    public class ReportByCustomTran
    {
       
        public string date_time_stamp { get; set; }
        public string date_in { get; set; }       
        public string date_out { get; set; }       
        public string stamp_code { get; set; }      
        public string license_plate { get; set; }      
        public string visitor_id { get; set; }
        
        public string admin_name { get; set; }
     
        public string active { get; set; }
        
        public string custom { get; set; }
        
        public string amount { get; set; }
    
        public string total_host { get; set; }
    }
}