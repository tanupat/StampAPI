using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parking.interfaces;
using Parking.Service;
using Parking.Models.Auth;

namespace Parking.Controllers
{
   // [Authorize]
  
    public class LoginController : ApiController
    {
        private IAccount account = new AccountService();
        private IAccount accountAPI = new APIParkingAccountService();
        private IAccessTokenService tokenservice = new JWTAccessTokenService();
      
        [Route("api/login")]
        [HttpGet]
        public UserLoginModel login(string user,string password)
        {
            try
            {
              //  UserLoginModel modelTest = accountAPI.Login(user, password);

                 UserLoginModel userlogin = new UserLoginModel();
                userlogin = account.Login(user, password);
                if (userlogin != null)
                {
                    userlogin.Status = "OK";
                    userlogin.Token = this.tokenservice.GennarateAccessToken(user, password);
                    return userlogin;
                }
                else {
                    return new UserLoginModel
                    {
                        Token = "",
                        AdminLevel = 0,
                        AdminId = 0,
                        Aminname = "",
                        CommanyName = "",
                        CompanyID = "",
                        Custom = "",
                        DeptID = "",
                        name = "",
                        Status ="ERROR"
                     
                    };
                }
             
            } catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
