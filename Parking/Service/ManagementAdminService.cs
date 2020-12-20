using Parking.Entity;
using Parking.interfaces;
using Parking.Models;
using Parking.Models.Register;
using Parking.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Parking.Service
{
    public class ManagementAdminService : IManagementAdmin
    {
        private clsDatabase _db = new clsDatabase();
        private WarpsystemEntities _dbWarp = new WarpsystemEntities();

        public List<AdminModel> AdminList()
        {
            List<AdminModel> model_admin = new List<AdminModel>();
            DataTable dt = new DataTable();
            string sql = "select t1.admin_ID,t1.admin_level_id,t1.adminname,t1.password1,t1.name,t1.Ternsubcode,t1.Terncode,t1.custom,t2.Zdesc from PkAdminweb t1 left join PKadminweb_level t2 on t1.admin_level_id = t2.admin_level_id";
            dt = this._db.QueryDataTable(sql);
            model_admin = (from c in dt.AsEnumerable() select new AdminModel {
                adminname = c["adminname"].ToString(),
                admin_ID = Convert.ToInt32(c["admin_ID"]),
                admin_level_id = Convert.ToInt32(c["admin_level_id"]),
                custom = c["custom"].ToString(),
                name = c["name"].ToString(),
                Terncode = c["Terncode"].ToString(),
                Ternsubcode = c["Ternsubcode"].ToString(),
                 Zdesc = c["Zdesc"].ToString(),
                 password= c["password1"].ToString()

            }).ToList();

            return model_admin;

        }

        public List<UserList> adminlist(string terncode, string ternsubcode, string admin_level)
        {
            List<UserList> list = new List<UserList>();
            DataTable dt = new DataTable();
            string sql = " select t1.admin_ID,t1.admin_level_id,t1.adminname,t1.password1,t1.name,t1.Terncode,t1.Ternsubcode,custom,t2.Zdesc,t3.Zdesc as admin_lv from  ";
            sql += " PkAdminweb t1 left join PkDepartments t2 on t1.Terncode = t2.Terncode and t1.Ternsubcode = t2.DeptID ";
            sql += "  left join PKadminweb_level t3 on t1.admin_level_id = t3.admin_level_id  ";
            sql += "  where t1.Terncode = '" + terncode + "' and t1.Ternsubcode = '" + ternsubcode + "' and t1.admin_level_id > " + admin_level + " order by t1.admin_level_id desc ";


            dt = this._db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new UserList
                    {
                        user_Id = c["admin_ID"].ToString(),
                        user_name = c["adminname"].ToString(),
                        name = c["name"].ToString(),
                        custom = c["custom"].ToString(),
                        department = c["Zdesc"].ToString(),
                        level_admin = c["admin_lv"].ToString()
                    }).ToList();

            return list;
        }

        public List<adminlevel_list> admin_level_list(string admin_lv_id)
        {
            List<adminlevel_list> list = new List<adminlevel_list>();
            DataTable dt = new DataTable();
            string sql = "select admin_level_id,Zdesc from PKadminweb_level where admin_level_id > " + admin_lv_id + " ";
            dt = this._db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new adminlevel_list
                    {
                        admin_lvId = c["admin_level_id"].ToString(),
                        admin_lv = c["Zdesc"].ToString()
                    }).ToList();


            return list;
        }

        public string delete_admin(string admin_id)
        {
            try
            {

                string sql = "delete from PkAdminweb where admin_ID = '" + admin_id + "'";
                this._db.QueryExecuteNonQuery(sql);
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public AdminModel getAdmminByadminName(string admin_name)
        {
            DataTable dt = new DataTable();
            AdminModel model = new AdminModel();
            string sql = "select t1.admin_ID,t1.admin_level_id,t1.adminname,t1.password1,t1.name,t1.Ternsubcode,t1.Terncode,t1.custom,t2.Zdesc from PkAdminweb t1 left join PKadminweb_level t2 on t1.admin_level_id = t2.admin_level_id  where t1.adminname = '" + admin_name+"'";
            dt = this._db.QueryDataTable(sql);
            model = (from c in dt.AsEnumerable() select new AdminModel {
                adminname = c["adminname"].ToString(),
                admin_ID = Convert.ToInt32(c["admin_ID"]),
                admin_level_id = Convert.ToInt32(c["admin_level_id"]),
                custom = c["custom"].ToString(),
                name = c["name"].ToString(),
                Terncode = c["Terncode"].ToString(),
                Ternsubcode = c["Ternsubcode"].ToString(),
                Zdesc = c["Zdesc"].ToString(),
                password = c["password1"].ToString()
            }).SingleOrDefault();

            return model;

        }

        public ResetPasswordModel getResetPassword(int admin_id)
        {
            ResetPasswordModel data_modal = new ResetPasswordModel();
            DataTable dt = new DataTable();
            string sql = "select t1.admin_ID,t1.adminname  from PkAdminweb t1 where t1.admin_ID = "+admin_id+" ";
            dt = this._db.QueryDataTable(sql);
            data_modal = (from c in dt.AsEnumerable() select new ResetPasswordModel {
                admin_ID = Convert.ToInt32(c["admin_ID"]),
                adminname = c["adminname"].ToString()
            }).SingleOrDefault();
            return data_modal;

        }

        public string insert_admin(RegisterModel model)
        {
            try
            {
                DataTable dt_exists = new DataTable();
                string sql_exists_user = "select adminname from PkAdminweb where adminname = '" + model.Login_name + "' ";
                dt_exists = this._db.QueryDataTable(sql_exists_user);
                string password_conver = MD5.CreateMD5(model.Password);

                if (dt_exists.Rows.Count > 0)
                {
                    return "user name exists";
                }

                string sql = "insert into PkAdminweb (adminname,password1,name,Terncode,Ternsubcode,admin_level_id,Custom) VALUES";
                sql += " ( ";
                sql += "'" + model.Login_name + "',";
                sql += "'" + password_conver + "',";
                sql += "'" + model.FullName + "',";
                sql += "'" + model.terncode + "',";
                sql += "'" + model.ternsubcode + "',";
                sql += "'" + model.admin_level + "',";
                sql += "'" + model.Custom + "' ";
                sql += " )";

                string result = this._db.QueryExecuteNonQuery(sql);



                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        

        public string update_admin(UpdateUserModel model)
        {
            try
            {
                string sql;
                if (model.Password != null)
                {
                    sql = "update PkAdminweb set adminname = '" + model.Login_name + "' ,name = '" + model.FullName + "',Terncode = '" + model.terncode + "',Ternsubcode = '" + model.ternsubcode + "',admin_level_id = '" + model.admin_level_update + "', password1 = '" + MD5.CreateMD5(model.Password) + "', Sf = 0, custom = '" + model.Custom + "'  where admin_ID = '" + model.uerId + "'";
                }
                else
                {
                    sql = "update PkAdminweb set adminname = '" + model.Login_name + "' ,name = '" + model.FullName + "',Terncode = '" + model.terncode + "',Ternsubcode = '" + model.ternsubcode + "',admin_level_id = '" + model.admin_level_update + "',  Sf = 0, custom = '" + model.Custom + "'  where admin_ID = '" + model.uerId + "'";
                }

                this._db.QueryExecuteNonQuery(sql);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

       

     

        public string update_password(UpdatePasswordModel model)
        {
            try
            {

                string sql = "update PkAdminweb set password1 = '" + MD5.CreateMD5(model.Password) + "', Sf = 0   where admin_ID = '" + model.uerId + "'";
                this._db.QueryExecuteNonQuery(sql);
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public UpdateUserModel UserDetail(string user_id)
        {
            UpdateUserModel _model = new UpdateUserModel();
            DataTable dt = new DataTable();
            string sql = "select admin_ID,admin_level_id,adminname,name,Ternsubcode,Terncode,custom,password1 from PkAdminweb where admin_ID = '" + user_id + "'";
            dt = this._db.QueryDataTable(sql);
            _model = (from c in dt.AsEnumerable()
                      select new UpdateUserModel
                      {
                          uerId = c["admin_ID"].ToString(),
                          admin_level_update = c["admin_level_id"].ToString(),
                          Login_name = c["adminname"].ToString(),
                          terncode = c["Terncode"].ToString(),
                          ternsubcode = c["Ternsubcode"].ToString(),
                          Custom = c["custom"].ToString(),
                          FullName = c["name"].ToString()
                          //Password = c["password1"].ToString(),
                          //ConfirmPassword = c["password1"].ToString()                   
                      }).SingleOrDefault();



            return _model;
        }

        public UpdatePasswordModel UserDetail_updatePassword(string user_id)
        {
            UpdatePasswordModel _model = new UpdatePasswordModel();
            DataTable dt = new DataTable();
            string sql = "select admin_ID,admin_level_id,adminname,name,Ternsubcode,Terncode,custom,password1 from PkAdminweb where admin_ID = '" + user_id + "'";
            dt = this._db.QueryDataTable(sql);
            _model = (from c in dt.AsEnumerable()
                      select new UpdatePasswordModel
                      {
                          uerId = c["admin_ID"].ToString(),
                          admin_level_update = c["admin_level_id"].ToString(),
                          Login_name = c["adminname"].ToString(),
                          terncode = c["Terncode"].ToString(),
                          ternsubcode = c["Ternsubcode"].ToString(),
                          Custom = c["custom"].ToString(),
                          FullName = c["name"].ToString()
                                          
                      }).SingleOrDefault();



            return _model;
        }

      

      
    }
}