using Parking.interfaces;
using Parking.Models.Auth;
using Parking.Models.Register;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Parking.Controllers
{
    [Authorize]
    public class RegisterUserController : ApiController
    {
        private IManagementAdmin _adminservice = new ManagementAdminService();
    
        [Route("api/stamp/adminlist")]
        [HttpGet]
        public List<UserList> AdminList() {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<UserList> list = new List<UserList>();
            list = this._adminservice.adminlist(
               Userdata.CompanyID,
               Userdata.DeptID,
              Userdata.AdminLevel.ToString()
                );
            return list;
        }
        [Route("api/stamp/RegisterUser")]
        [HttpPost]
        public IHttpActionResult RegisterUser(RegisterModel _model)
        {
            string result = this._adminservice.insert_admin(_model);
            return Ok(new { mes="Ok" });
        }

        [Route("api/stamp/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(UpdateUserModel _model)
        {
            this._adminservice.update_admin(_model);
            return Ok();
        }


        [Route("api/stamp/DeleteUser")]
        [HttpPost]
        public IHttpActionResult DeleteUser(string adminId)
        {
            this._adminservice.delete_admin(adminId);
            return Ok();
        }

        [Route("api/stamp/UserDetail")]
        [HttpGet]
        public UpdateUserModel UserDetail(string user_id)
        {
            UpdateUserModel user = new UpdateUserModel();
            user = this._adminservice.UserDetail(user_id);
            return user;
        }
        [Route("api/stamp/Leveladmin")]
        [HttpGet]
        public List<adminlevel_list> adminlevelList()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];
            List<adminlevel_list> list = new List<adminlevel_list>();
            
            list = this._adminservice.admin_level_list(Userdata.AdminLevel.ToString());
            return list;
        }

        [Route("api/stamp/admin/GetAlladminList")]
        [HttpGet]
        public List<AdminModel> GetAlladminList()
        {
            List<AdminModel> list = new List<AdminModel>();
            list = this._adminservice.AdminList();
            return list;

        }

        [Route("api/stamp/admin/GetadminByadminname")]
        [HttpGet]
        public AdminModel GetadminByadminname(string admin_name)
        {
            AdminModel model = new AdminModel();
            model = this._adminservice.getAdmminByadminName(admin_name);
            return model;

        }
        [Route("api/stamp/admin/GetResetPassword")]
        [HttpGet]
        public ResetPasswordModel GetResetPassword()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];
            ResetPasswordModel model = new ResetPasswordModel();
            model = this._adminservice.getResetPassword(Userdata.AdminId);
            return model;
        }
        [Route("api/stamp/admin/Updatepassword")]
        [HttpPost]
        public IHttpActionResult Updatepassword(UpdatePasswordModel data)
        {
            this._adminservice.update_password(data);
            return Ok();
        }

    }
}
