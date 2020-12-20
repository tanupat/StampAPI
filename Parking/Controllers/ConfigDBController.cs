using Parking.interfaces;
using Parking.Models.ConfigDBModel;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parking.Controllers
{
    public class ConfigDBController : Controller
    {
        private IDbConfig dbConfig = new ConfigDbService();
        public ActionResult ConfigDB() {
            ConfigDBModel model = new ConfigDBModel();
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            string ServerName = Environment.MachineName;
            List<SelectListItem> ServerNameList = new List<SelectListItem>();
            foreach (DataRow row in table.Rows)
            {

                ServerNameList.Add(new SelectListItem
                {
                    Text = ServerName + "\\" + row["InstanceName"].ToString(),
                    Value = ServerName + "\\" + row["InstanceName"].ToString()
                } );
               
                
            }
           // ViewBag.ServerNameList = new SelectList(ServerNameList, "kaizen_type_id", "kaizen_type");
            ViewData["ServerNameList"] = ServerNameList;
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfigDB(ConfigDBModel data) {
         
            DataTable dt_dbName = new DataTable();
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            string ServerName = Environment.MachineName;
            List<SelectListItem> ServerNameList = new List<SelectListItem>();
            foreach (DataRow row in table.Rows)
            {

                ServerNameList.Add(new SelectListItem
                {
                    Text = ServerName + "\\" + row["InstanceName"].ToString(),
                    Value = ServerName + "\\" + row["InstanceName"].ToString()
                });


            }
            ViewData["ServerNameList"] = ServerNameList;
            //if (!ModelState.IsValid)
            //{

            //    return View(data);
            //}
            try
            {


                List<SelectListItem> dataBaseName = new List<SelectListItem>();
                dt_dbName = dbConfig.GetdataBaseName(data.servernameSelect, data.user, data.password);

                if (dt_dbName.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_dbName.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            dataBaseName.Add(new SelectListItem
                            {
                                Text = item.ToString(),
                                Value = item.ToString()
                            });                          
                        }
                        ViewData["dataBaseNameList"] = dataBaseName;
                    }

                    if (data.database_name != null)
                    {
                        this.dbConfig.SetWebConfig(data.servernameSelect, data.user, data.password, data.database_name);
                    }
                }

                return View(data);
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
         
           
        }
    }
}