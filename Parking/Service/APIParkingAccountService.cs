using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Auth;
using Parking.Models;
using Newtonsoft.Json;
namespace Parking.Service
{
    public class APIParkingAccountService : IAccount
    {
        private GetDataAPI get_api = new GetDataAPI();
        public UserLoginModel Login(string username, string password)
        {
            UserLoginModel model = new UserLoginModel();
            string json = get_api.getDataOtherAPI("http://www.psspark.com/api/login?username=admin&password=1234");
            model = JsonConvert.DeserializeObject<UserLoginModel>(json);
            return model;
        }

        public bool LogLoginToken(string token, DateTime exprise, string user_name)
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}