using Parking.interfaces;
using Parking.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Auth;
using System.Data;
using Parking.Service;
using Parking.Models;

namespace Parking.Service
{
    public class AccountService : IAccount
    {

        private clsDatabase db = new clsDatabase();

       // private IAccessTokenService token = new JWTAccessTokenService();

        public bool LogLoginToken(string token, DateTime exprise, string user_name)
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string password)
        {
            throw new NotImplementedException();
        }



     public   UserLoginModel Login(string username, string password)
        {
            try
            {
                string _password = MD5.CreateMD5(password);
                DataTable dt = new DataTable();
                UserLoginModel detail_login = new UserLoginModel();
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
                                             " where (PkAdminweb.adminname = '" + username + "' and PkAdminweb.password1 = '" + _password + "')";
                dt = this.db.QueryDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    detail_login = (from c in dt.AsEnumerable()
                                    select new UserLoginModel
                                    {
                                        AdminId = Convert.ToInt32(c["admin_ID"]),
                                        name = c["name"].ToString(),
                                        AdminLevel = Convert.ToInt32(c["admin_level_id"]),
                                        Aminname = c["adminname"].ToString(),
                                        CommanyName = c["DeptName"].ToString(),
                                        CompanyID = c["Terncode"].ToString(),
                                        DeptID = c["Ternsubcode"].ToString(),
                                        Custom = c["Custom"].ToString(),
                                       // Token = token.GennarateAccessToken(username, _password)
                                        
                                    }).SingleOrDefault();
                    return detail_login;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}