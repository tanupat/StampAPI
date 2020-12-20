using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Parking.interfaces;
using Parking.Service;
using System.Threading.Tasks;
using System.Threading;
using Parking.Models.Auth;
using System.Security.Principal;

namespace Parking.App_Start
{
    
    public class AuthenticationHandler: DelegatingHandler
    {
        private IAccessTokenService accsessTokenService;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
              var Autoorization = request.Headers.Authorization;
            if (Autoorization != null)
            {
                string accsesstoken = Autoorization.Parameter;
                string accesstokenType = Autoorization.Scheme;
                if (accesstokenType.Equals("Bearer")) {

                    this.accsessTokenService = new JWTAccessTokenService();
                    var item = this.accsessTokenService.VerifyAccessToken(accsesstoken);
                    if (item != null)
                    {
                        var UserLogin = new UserLogin(new GenericIdentity(item.Aminname));
                        UserLogin._userlogin = item;
                        Thread.CurrentPrincipal = UserLogin;
                        HttpContext.Current.User = UserLogin;
                        HttpContext.Current.Items.Add("user_data", item);
                    }
                }
            }
            return base.SendAsync(request, cancellationToken);
         }
     }

    public class UserLogin : GenericPrincipal {
        public UserLoginModel _userlogin { get; set; }
        public UserLogin(IIdentity identity) :base (identity,new string[] { })
        {

        }
    }
}