using Parking.interfaces;
using Parking.Models.Stamp;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class SummaryByStampModel
    {
        private IStamp _stamp_service = new StampService();
        public string terncode { get; set; }
      
        public string start_date { get; set; }
       
        public string end_date { get; set; }
        
        public string stamp_code { get; set; }
       
        public string car_type { get; set; }
        public List<SummaryByStampTran> summary_list { get; set; }

        public List<Car_type> Car_type_list
        {
            get
            {
                return new List<Car_type> {
                    new Car_type { Car_type_code = "0",  Car_type_name = "selectAll" },
                    new Car_type { Car_type_code = "1",  Car_type_name = "Car" },
                    new Car_type { Car_type_code = "2", Car_type_name = "motorcycle" }
                };
            }
        }

        public List<stampCodeList> stamp_code_list
        {
            get
            {
                List<stampCodeList> list = new List<stampCodeList>();
                list = this._stamp_service.stamp_code_all(this.terncode);
                return list;
            }
        }

    }
    public class SummaryByStampTran
    {
       
        public string stamp_code { get; set; }
        
        public string date_count { get; set; }
        
        public string stamp_count { get; set; }
       
        public string toltal_amont { get; set; }
    }
}