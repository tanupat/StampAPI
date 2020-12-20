using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.StampReport
{
    public class StampTranModel
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
        public string Hour_total { get; set; }
    }
}