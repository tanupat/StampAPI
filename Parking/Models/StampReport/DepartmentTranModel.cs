using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class DepartmentTranModel
    {
        public  DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string ternsubcode { get; set; }
        public string car_type { get; set; }
        public string sCompanyID { get; set; }
    }
}