using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parking.Models.ConfigDBModel
{
    public class ConfigDBModel
    {
        [Required]
        [Display(Name = "Server name")]
        public string servernameSelect { get; set; }
        [Required]
        [Display(Name = "User")]
        public string  user { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
       
        [Display(Name = "Database name")]
        public string database_name { get; set; }

      
    }
}