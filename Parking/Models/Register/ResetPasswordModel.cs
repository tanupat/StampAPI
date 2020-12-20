using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Register
{
    public class ResetPasswordModel
    {
        public int admin_ID { get; set; }
        public string adminname { get; set; }
        public string password1 { get; set; }
    }
}