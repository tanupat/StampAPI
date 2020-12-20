using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface Ilog
    {
        string insert_log(String Adminname, String UserName, String PRG, String Topic, String SubTopic, String ActionFlag, String OldValue, String NewValue, String Memo, String Deviceno, String AdminLevel, String Last_Upd, String TableName, String inouttranstampid);
    }
}
