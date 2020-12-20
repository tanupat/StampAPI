using Parking.Models.Stamp;
using Parking.Models.StampReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface IStamp
    {
        StampModel InOutTranDetail(string visitorId, string terncode, string ternsubcode, string adminlevel);
        TranVisitorModel GetVisitorInOut(string visitorID);
        ChangeStampModel CheangeStamp(string ternCode, string ternSubCode, string inoutTrainStamp, string visitor_id, int? adminLevel);
        bool CheckTheStampRepeat(string stampCode, string inOutTran);
        void insertStamp(string stampCode, string inout_tran, string ternCode, string ternsubCode, int? level, string custom, string admin_name, string custom_stamp);
        List<ActiveStampModel> ActiveStampList(string terncode, string tersubcode, string adminLevel);
        string UpdateStamp(string stampCode, string inoutTranID, string inoutTranStamp);
        void DeleteStamp(string stampcode, string inoutTrainStamp);
        List<stampCodeList> stamp_code_all(string terncode);
        List<CustomModel> custom_stamp(string tercode, string ternsubcode);
        List<AdminModel> admin_list(string ternCode, string adminlevel);
        List<MessageWebModel> get_MessageWeb();
    }
}
