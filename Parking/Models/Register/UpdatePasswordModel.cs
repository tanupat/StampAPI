using Parking.interfaces;
using Parking.Models.Stamp;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Register
{
    public class UpdatePasswordModel
    {
        private IManagementAdmin _register = new ManagementAdminService();
     
        public string uerId { get; set; }
        
        public string Login_name { get; set; }
       
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
       
        public string FullName { get; set; }     
       
        public string terncode { get; set; }
        
        public string Custom { get; set; }
       
        public string ternsubcode { get; set; }
        
        public string admin_level { get; set; }
        
        public string admin_level_update { get; set; }

           
    }


}
