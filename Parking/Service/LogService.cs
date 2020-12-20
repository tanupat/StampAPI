using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models;
using Parking.interfaces;

namespace Parking.Service
{
    
    public class LogService: Ilog
    {
        private clsDatabase _db = new clsDatabase();
        public string insert_log(string Adminname, string UserName, string PRG, string Topic, string SubTopic, string ActionFlag, string OldValue, string NewValue, string Memo, string Deviceno, string AdminLevel, string Last_Upd, string TableName, string inouttranstampid)
        {
            string sql = "INSERT INTO Pkadminweblog(Adminname, UserName, LogDate, PRG, Topic, SubTopic, ActionFlag, OldValue, NewValue, Memo, Deviceno, AdminLevel, Last_Upd, table1, keyid) VALUES('" + Adminname + "', '" + UserName + "', getdate(), '" + PRG + "', '" + Topic + "', '" + SubTopic + "', " + ActionFlag + ", '" + OldValue + "', '" + NewValue + "', '" + Memo + "', '" + Deviceno + "', '" + AdminLevel + "', '" + Last_Upd + "', '" + TableName + "', '" + inouttranstampid + "')";
            _db.QueryExecuteNonQuery(sql);
            return "Ok";
        }
    }
}