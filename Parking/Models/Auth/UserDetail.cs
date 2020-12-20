using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Auth
{
    public class UserDetail
    {
             public string admin_ID { get; set; }
             public int admin_level_id { get; set; }
             public string Aminname { get; set; }
             public string name { get; set; }
             public string Ternsubcode { get; set; }
             public string Terncode { get; set; }
             public string custom { get; set; }
             public string Zdesc { get; set; }
             public string DeptName { get; set; }
             public string Token { get; set; }
    }
}