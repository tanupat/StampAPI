using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Parking.Service
{
    public class ConfigDbService : IDbConfig
    {
        private SqlConnection objConn;
        private SqlCommand objCmd;
        public DataTable GetdataBaseName(string server_name,string user, string password)
        {
            try
            {
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                objConn = new SqlConnection();
                objConn.ConnectionString = @"data source="+server_name+";initial catalog=master;user id="+user+";password="+password+";MultipleActiveResultSets=True;";
                //@"data source=NOTE-LENOVO2434\SQLEXPRESS02;initial catalog=WarpsystemV3;user id=sa;password=Ton07110711;MultipleActiveResultSets=True;";
                //"Data Source="+server_name+";Initial Catalog=master;User ID="+user+";Password="+password+"";
                objConn.Open();

                dtAdapter = new SqlDataAdapter("SELECT DB_NAME(database_id) AS [Database]  FROM sys.databases where DB_NAME(database_id) not in ('master','tempdb','model','msdb')", objConn);
                dtAdapter.Fill(dt);
                objConn.Close();
                return dt; //*** Return DataTable ***//
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetWebConfig(string serverName, string user, string password, string dbName)
        {
            ExeConfigurationFileMap FileMap = new ExeConfigurationFileMap();
            FileMap.ExeConfigFilename = HttpContext.Current.Server.MapPath(@"~\Web.config");
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(FileMap, ConfigurationUserLevel.None);

            // Define the string name.
            string csName = "WarpsystemEntities";
            ConnectionStringsSection RemoveSection = config.ConnectionStrings;
            RemoveSection.ConnectionStrings.Remove(
                new ConnectionStringSettings(csName, "" +
                    "", ""));
            config.Save(ConfigurationSaveMode.Modified);

           string conString =  String.Format(@"metadata=res://*/Entity.dbWarpSystem.csdl|res://*/Entity.dbWarpSystem.ssdl|res://*/Entity.dbWarpSystem.msl;provider=System.Data.SqlClient;provider connection string=""data source={0};initial catalog={1};user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework""",serverName,dbName,user,password);
            // Add the connection string.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Add(
                new ConnectionStringSettings(csName,
                    conString
                    , "System.Data.EntityClient"));
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

        }
    }
}