using Parking.Models.Stamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface ICompany
    {
        List<CompanyModel> CheckLevelCompany(string ternCode);

        string CompanyName(string terncode, string ternsubcode);
    }
}
