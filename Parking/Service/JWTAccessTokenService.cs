using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Auth;
using Jose;
using System.Text;
using Parking.Models;
using System.Data;
using Parking.Entity;
using Parking.util;

namespace Parking.Service
{
    public class JWTAccessTokenService : IAccessTokenService
    {
        private byte[] secretKey = Encoding.UTF8.GetBytes("qawsedrftgyhujikolp");
        private IAccount account = new AccountService();
        private clsDatabase dabase = new clsDatabase();
        private WarpsystemEntities db = new WarpsystemEntities();

        public UserLoginModel VerifyAccessToken(string accesToken)
        {
            try {
                UserLoginModel user_login = new UserLoginModel();
                DataTable dt = new DataTable();
                JWTPayload payload = JWT.Decode<JWTPayload>(accesToken, this.secretKey);
                if (payload == null) return null;
                if (payload.exp < DateTime.UtcNow) return null;

                string sql = " select PkAdminweb.admin_ID, " +
                                            " PkAdminweb.name, " +
                                            " PkAdminweb.admin_level_id, " +
                                            " PkAdminweb.Terncode,  " +
                                            " PkAdminweb.Ternsubcode," +
                                            " PkDepartments.DeptName, " +
                                            " PkAdminweb.adminname , " +
                                            " PkAdminweb.Custom " +
                                            " from PkAdminweb  " +
                                            " left join PkAdminweb_level on PkAdminweb.admin_level_id = PkAdminweb_level.admin_level_id " +
                                            " left join PkDepartments on PkAdminweb.Ternsubcode = PkDepartments.DeptID and PkAdminweb.Terncode = PkDepartments.CompanyID " +
                                            " where (PkAdminweb.adminname = '" + payload.username + "' )";

                dt = dabase.QueryDataTable(sql);

                user_login = (from c in dt.AsEnumerable()
                              select new UserLoginModel
                              {
                                  AdminId = Convert.ToInt32(c["admin_ID"]),
                                  name = c["name"].ToString(),
                                  AdminLevel = Convert.ToInt32(c["admin_level_id"]),
                                  Aminname = c["adminname"].ToString(),
                                  CommanyName = c["DeptName"].ToString(),
                                  CompanyID = c["Terncode"].ToString(),
                                  DeptID = c["Ternsubcode"].ToString(),
                                  Custom = c["Custom"].ToString()
                              }).SingleOrDefault();

                return user_login;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GennarateAccessToken(string username, string password, int day = 1)
        {
            JWTPayload payload = new JWTPayload
            {
                username = username,
                exp = DateTime.Now.AddDays(day)
               
            };
            string token = JWT.Encode(payload, this.secretKey, JwsAlgorithm.HS256);
            return token;
        }
    }

    public class JWTPayload
    {
        public string username { get; set; }
        public DateTime exp { get; set; }

    }
}