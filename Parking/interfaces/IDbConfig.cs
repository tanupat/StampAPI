using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface IDbConfig
    {
        DataTable GetdataBaseName(string server_name,string user,string password);
        void SetWebConfig(string serverName,string user,string password,string dbName);
    }
}
