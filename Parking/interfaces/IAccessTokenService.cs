using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Models.Auth;

namespace Parking.interfaces
{
    interface IAccessTokenService
    {
        string GennarateAccessToken(string username, string password, int day = 1);
        UserLoginModel VerifyAccessToken(string accesToken);
    }
}
