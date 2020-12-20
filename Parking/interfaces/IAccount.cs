using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Models.Auth;
namespace Parking.interfaces
{
    interface IAccount
    {
        void Register(string username, string password);
        UserLoginModel Login(string username, string password);
        bool LogLoginToken(string token, DateTime exprise, string user_name);
    }
}
