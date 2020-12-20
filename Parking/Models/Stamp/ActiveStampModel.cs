using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Stamp
{
    public class ActiveStampModel
    {
        public string InoutTrainStamp { get; set; }   
        public DateTime TimeStamp { get; set; }   
        public string visitor_id { get; set; }   
        public string license_plate { get; set; }
        public string StampCode { get; set; }
    }
}