using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Stamp;
using Parking.Models.StampReport;
using Parking.Models;
using Parking.Models.Auth;
using Newtonsoft.Json;

namespace Parking.Service
{

    public class APIParkingStampService : IStamp
    {
        private clsDatabase db = new clsDatabase();
        private IAccount account = new APIParkingAccountService();
        private GetDataAPI get_api = new GetDataAPI();

      
        public List<ActiveStampModel> ActiveStampList(string terncode, string tersubcode, string adminLevel)
        {
            throw new NotImplementedException();
        }

        public List<AdminModel> admin_list(string ternCode, string adminlevel)
        {
            throw new NotImplementedException();
        }

        public ChangeStampModel CheangeStamp(string ternCode, string ternSubCode, string inoutTrainStamp, string visitor_id, int? adminLevel)
        {
            throw new NotImplementedException();
        }

        public bool CheckTheStampRepeat(string stampCode, string inOutTran)
        {
            throw new NotImplementedException();
        }

        public List<CustomModel> custom_stamp(string tercode, string ternsubcode)
        {
            throw new NotImplementedException();
        }

        public void DeleteStamp(string stampcode, string inoutTrainStamp)
        {
            throw new NotImplementedException();
        }

        public TranVisitorModel GetVisitorInOut(string visitorID)
        {
            throw new NotImplementedException();
        }

        public StampModel InOutTranDetail(string visitorId, string terncode, string ternsubcode, string adminlevel)
        {
            UserLoginModel userLogin = account.Login("admin","admin");
            string json = get_api.getDataOtherAPI("http://www.psspark.com/api/login?username=admin&password=1234");
            //string json = get_api.getDataWithToken("http://localhost:8085/stamp/api/getInOutDeatil?visitorId=" + visitorId + "&terncode=" + terncode + "&trensubcode="+ternsubcode+"&adminlevel="+adminlevel, userLogin.Token, "GET");
            StampModel stampModel = JsonConvert.DeserializeObject<StampModel>(json);
            return stampModel;
            
            //throw new NotImplementedException();
        }

        public void insertStamp(string stampCode, string inout_tran, string ternCode, string ternsubCode, int? level, string custom, string admin_name, string custom_stamp)
        {
            throw new NotImplementedException();
        }

        public List<stampCodeList> stamp_code_all(string terncode)
        {
            throw new NotImplementedException();
        }

        public string UpdateStamp(string stampCode, string inoutTranID, string inoutTranStamp)
        {
            throw new NotImplementedException();
        }

        public List<MessageWebModel> get_MessageWeb()
        {
            throw new NotImplementedException();
        }
    }
}