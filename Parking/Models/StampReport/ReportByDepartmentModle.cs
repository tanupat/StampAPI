using Parking.interfaces;
using Parking.Models.Stamp;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class ReportByDepartmentModle
    {
        private IStamp _stamp_service = new StampService();
        private ICompany _company = new CompanyService();

       
     
        public string start_date { get; set; }   
        public string end_date { get; set; }
        public string terncode { get; set; }      
        public string ternsubcode { get; set; }     
        public string car_type { get; set; }
        public List<stamp_report_department_tran> stamp_tran { get; set; }
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

        public List<CompanyModel> department_list
        {
            get
            {
                List<CompanyModel> list_company = new List<CompanyModel>();
                list_company = this._company.CheckLevelCompany(this.terncode);
                return list_company;
            }
        }


    }

    public class stamp_report_department_tran
    {
  
        public string department { get; set; }
    
        public DateTime date_count { get; set; }
        public int count { get; set; }
        public string amount { get; set; }
    }
}