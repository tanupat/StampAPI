using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parking.Models;
using System.Data;
using Parking.Service;
using Parking.interfaces;
using Parking.Models.Register;
using Parking.Models.Auth;
using System.Web;

namespace Parking.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private clsDatabase db = new clsDatabase();
        private IManagementAdmin _adminservice = new ManagementAdminService();
        [Route("api/user/user_detail")]
        [HttpGet]
        public UserDetail GetUserDetail()
        {
            UserDetail model = new UserDetail();
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            DataTable dt = new DataTable();
            string sql = " select t1.admin_ID,";
            sql += " t1.admin_level_id,";
            sql += " t1.adminname, ";
            sql += " t1.name, ";
            sql += " t1.Ternsubcode, ";
            sql += " t1.Terncode, ";
            sql += " t1.custom ,";
            sql += " t2.Zdesc, ";
            sql += " t3.DeptName from  PkAdminweb t1 ";
            sql += " left join PKadminweb_level t2  on t1.admin_level_id = t2.admin_level_id ";
            sql += " left join PkDepartments t3  on t1.Terncode = t3.CompanyID and t1.Ternsubcode = t3.DeptID ";
            sql += " where t1.admin_ID = '"+ Userdata.AdminId + "'";
                dt =  db.QueryDataTable(sql);

            model = (from c in dt.AsEnumerable() select new UserDetail
            {
                admin_ID =  c["admin_ID"].ToString(),
                admin_level_id = Convert.ToInt32( c["admin_level_id"]),
                Aminname= c["adminname"].ToString(),
                name = c["name"].ToString(),
                Ternsubcode = c["Ternsubcode"].ToString(),
                Terncode = c["Terncode"].ToString(),
                custom = c["custom"].ToString(),
                Zdesc = c["Zdesc"].ToString(),
                DeptName = c["DeptName"].ToString()
            }).SingleOrDefault();
            return model;
        }
        [Route("api/user/GetMenuLiist")]
        [HttpGet]
        public List<MenuModel> GetMenuLiist()
        {
            List<MenuModel> list = new List<MenuModel>();
            DataTable dt = new DataTable();
            string sql = "SELECT  [admin_level_id],[Htag1],[Tag1],[Topic1],[Active1] FROM [dbo].[Pkadminweb_levelsub]";
            dt = db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable() select new MenuModel {
                 Active1 = Convert.ToInt32(c["Active1"]),
                 admin_level_id = Convert.ToInt32( c["admin_level_id"]),
                 Htag1 = Convert.ToInt32(c["Htag1"]),
                 Tag1 = Convert.ToInt32(c["Tag1"]),
                 Topic1 = c["Topic1"].ToString()
            }).ToList();
            return list;
        }
        [Route("api/user/GetUserlist")]
        [HttpGet]
        public List<UserList> GetUserlist(string sCompanyID,string sDeptID,string sAdminLevel)
        {
            List<UserList> list = new List<UserList>();
            list = this._adminservice.adminlist(sCompanyID,sDeptID,sAdminLevel);
            return list;
        }
             
    }
}
