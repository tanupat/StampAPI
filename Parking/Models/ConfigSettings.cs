using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Configuration;
using System.Reflection;

namespace Parking.Models
{
    public class ConfigSettings
    {
        private ConfigSettings() { }

        public static string ReadSetting(string key)
        {
           
            return ConfigurationManager.ConnectionStrings[key].ToString();
                //ConfigurationSettings.AppSettings[key];
        }

        public static void WriteSetting(string key, string value)
        {
            // Remove File Connect String
   

            // End Remove


            // load config document for current assembly
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

            string conString = @"metadata=res://*/Entity.dbWarpSystem.csdl|res://*/Entity.dbWarpSystem.ssdl|res://*/Entity.dbWarpSystem.msl;provider=System.Data.SqlClient;provider connection string=""data source=NOTE-LENOVO2434\SQLEXPRESS02;initial catalog=WarpsystemV3;user id=sa;password=Ton07110711;MultipleActiveResultSets=True;App=EntityFramework""";
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

        public static void RemoveSetting(string key)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//connectionStrings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    doc.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
            }
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private static string getConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }
    }
}