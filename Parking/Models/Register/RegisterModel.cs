using Parking.interfaces;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Register
{
    public class RegisterModel
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
    public class UserList
    {
        public string user_Id { get; set; }
       
        public string user_name { get; set; }
        
        public string department { get; set; }
       
        public string name { get; set; }
        
        public string level_admin { get; set; }
        
        public string custom { get; set; }

    }
    public class adminlevel_list
    {
        public string admin_lvId { get; set; }
        public string admin_lv { get; set; }
    }
}