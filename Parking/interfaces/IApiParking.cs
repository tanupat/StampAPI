using Parking.Models.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface IApiParking
    {
        List<APIModel> GetAPIByPrefix(string Prefix);
        List<APIModel> GetAllAPI();
        string GetTokenAPI(string user, string password);
    }
}
