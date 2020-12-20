using Parking.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface IManagementAdmin
    {
        List<UserList> adminlist(string terncode, string ternsubcode, string admin_level);
        List<adminlevel_list> admin_level_list(string admin_lv_id);
        string insert_admin(RegisterModel model);
        UpdateUserModel UserDetail(string user_id);
        string delete_admin(string admin_id);
        string update_admin(UpdateUserModel model);
        string update_password(UpdatePasswordModel model);
        UpdatePasswordModel UserDetail_updatePassword(string user_id);
        List<AdminModel> AdminList();
        AdminModel getAdmminByadminName(string admin_name);
        ResetPasswordModel getResetPassword(int admin_id);
    }
}
