using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.APIModel
{
    public class APIModel
    {
        public int APIId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CardPrefix { get; set; }
        public int Require_Token { get; set; }
        public string token { get; set; }
    }
}