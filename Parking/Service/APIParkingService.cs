using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.APIModel;
using Parking.Models;
using System.Data;

namespace Parking.Service
{
    public class APIParkingService : IApiParking
    {
        private clsDatabase db = new clsDatabase();

        public List<APIModel> GetAllAPI()
        {

            List<APIModel> list = new List<APIModel>();
            DataTable dt = new DataTable();
            string sql = "SELECT [API_ID] ";
            sql += " ,[Description] ";
            sql += " ,[Url] ";
            sql += " ,[CardPrefix] ";
            sql += " ,[Require_Token] ";
            sql += " ,[token] ";
            sql += " FROM [dbo].[PkAPI_Parking]  ";
            dt = db.QueryDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                list = (from c in dt.AsEnumerable()
                        select new APIModel
                        {
                            APIId = Convert.ToInt32(c["API_ID"]),
                            Description = c["Description"].ToString(),
                            CardPrefix = c["CardPrefix"].ToString(),
                            Url = c["Url"].ToString(),
                            Require_Token = Convert.ToInt32(c["Require_Token"]),
                            token = c["token"].ToString()
                        }).ToList();
            }

            return list;
        }

        public List<APIModel> GetAPIByPrefix(string Prefix)
        {
            List<APIModel> list = new List<APIModel>();
            DataTable dt = new DataTable();
            string sql = "SELECT [API_ID] ";
            sql += " ,[Description] ";
            sql += " ,[Url] ";
            sql += " ,[CardPrefix] ";
            sql += " ,[Require_Token] ";
            sql += " ,[token] ";
            sql += " FROM [dbo].[PkAPI_Parking] where CardPrefix = '"+Prefix+"' ";
            dt =  db.QueryDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                list = (from c in dt.AsEnumerable() select new APIModel {
                     APIId = Convert.ToInt32( c["API_ID"]),
                     Description = c["Description"].ToString(),
                     CardPrefix = c["CardPrefix"].ToString(),
                     Url = c["Url"].ToString(),
                     Require_Token = Convert.ToInt32( c["Require_Token"]),
                      token = c["token"].ToString()
                }).ToList();
            }

            return list;

        }

        public string GetTokenAPI(string user, string password)
        {

           
            throw new NotImplementedException();
        }
    }
}