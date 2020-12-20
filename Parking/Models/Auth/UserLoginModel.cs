using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Auth
{
    public class UserLoginModel
    {
        public int AdminId { get; set; }
        public string name { get; set; }
        public string CommanyName { get; set; }
        public string DeptID { get; set; }
        public string CompanyID { get; set; }
        public int AdminLevel { get; set; }
        public string Aminname { get; set; }
        public string Custom { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }

    }
}