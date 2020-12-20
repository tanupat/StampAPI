using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Stamp;

namespace Parking.Models.StampReport
{
    public class StampReportModel
    {
       
        public string start_date { get; set; }     
        public string end_date { get; set; }    
        public string stamp_code { get; set; }    
        public string TernsubCode { get; set; }  
        public string in_out { get; set; }     
        public string stamp_status { get; set; }    
        public string car_type { get; set; }
        public List<StampTranModel> stamp_tran { get; set; }
        public List<CompanyModel> DepartmentList { get; set; }
        public List<stampCodeList> stamp_code_list { get; set; }

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
                    new Car_type { Car_type_code = "C",  Car_type_name = "Car"  },
                    new Car_type { Car_type_code = "M", Car_type_name = "motorcycle" }
                };
            }
        }

    }
    public class in_out
    {
        public string in_out_id { get; set; }
        public string inout { get; set; }
    }
    public class stamp_status
    {
        public int status_id { get; set; }
        public string status_name { get; set; }
    }
    public class Car_type
    {
        public string Car_type_code { get; set; }
        public string Car_type_name { get; set; }
    }
}
