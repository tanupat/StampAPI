using Parking.Models.Stamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parking.Models;
using System.Data;
using Parking.interfaces;
using Parking.Service;
using System.Web;
using System.IO;
using System.Text;
using Parking.Models.Auth;

namespace Parking.Controllers
{
    [Authorize]
    public class StampController : ApiController
    {
        private IStamp stampservice = new StampService();
        private Ilog _log = new LogService();
        // private GetDataAPI get_api = new GetDataAPI();
        private IAccount accountPAI = new APIParkingAccountService();
        private clsDatabase db = new clsDatabase();
        [Route("stamp/api/getVisitor")]
        [HttpGet]
        public TranVisitorModel GetVisitorInOut(string visitorID)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            TranVisitorModel data_visitor = new TranVisitorModel();
            StampModel _stampModel = new StampModel();
            data_visitor =   this.stampservice.GetVisitorInOut(visitorID);

          
          //  return webData;
            return data_visitor;
        }


        
        [Route("stamp/api/getInOutDetail")]
        [HttpGet]
        public StampModel GetInOutDetail(string visitorId)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            StampModel _stampmodel = new StampModel();
            _stampmodel = this.stampservice.InOutTranDetail(visitorId,Userdata.CompanyID,Userdata.DeptID,Userdata.AdminLevel.ToString());
            ///accountPAI.Login("admin", "admin");
            return _stampmodel;
        }

        [Route("stamp/api/insertStamp")]
        [HttpPost]
        public IHttpActionResult InsertStamp(InsertStamp model)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            if (this.stampservice.CheckTheStampRepeat(model.StampCodeSelect, model.inoutTrainID)) {
                return Ok(new { mes = "StampDuplicate" });
            }

            this.stampservice.insertStamp(model.StampCodeSelect, model.inoutTrainID, Userdata.CompanyID, Userdata.DeptID, Userdata.AdminLevel,Userdata.Custom, Userdata.Aminname, model.custom);
            this._log.insert_log(Userdata.name,Userdata.Aminname, "WEB","Stamp","Stamp "+model.StampCodeSelect,"3","","","",ip,Userdata.AdminLevel.ToString(), DateTime.Now.ToString(),"","");
            return Ok(new { mes = "StampOk" });
        }

        [Route("stamp/api/ActiveStamp")]
        [HttpGet]
        public List<ActiveStampModel> ActiveStamp()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<ActiveStampModel> list = new List<ActiveStampModel>();
            list = this.stampservice.ActiveStampList(Userdata.CompanyID, Userdata.DeptID, Userdata.AdminLevel.ToString());

            return list;
        }


        [Route("stamp/api/ChangeStamp")]
        [HttpGet]
        public ChangeStampModel ChangeStamp(string inoutTrainStamp, string visitor_id) {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];
            ChangeStampModel model = new ChangeStampModel();
            model = this.stampservice.CheangeStamp(Userdata.CompanyID,Userdata.DeptID,inoutTrainStamp,visitor_id,Userdata.AdminLevel);
            return model;
        }

        [Route("stamp/api/updatesStamp")]
        [HttpPost]
        public IHttpActionResult ChangeStamp(ChangeStampModel model)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            string ip = HttpContext.Current.Request.UserHostAddress;
            string result = this.stampservice.UpdateStamp(model.stampCode, model.inoutTranID, model.inoutTrainStampID);
          


            this._log.insert_log(
               Userdata.Aminname, Userdata.name, "WEB", "ChangeStamp", "Change " + model.stampCode, "5", model.stampCodeOld, "", "", ip, Userdata.AdminLevel.ToString(), DateTime.Now.ToString(), "", "");

            //List<ActiveStampModel> list = new List<ActiveStampModel>();
            //list = this.stampservice.ActiveStampList(Userdata.CompanyID, Userdata.DeptID, Userdata.AdminLevel.ToString());
            //data_active_stamp = list
            return Ok(new { mes = result });
        }

        [Route("stamp/api/deleteStamp")]
        [HttpPost]
        public IHttpActionResult DeleteStamp(DeleteStamp model)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];



            this.stampservice.DeleteStamp(model.stampcode, model.inoutTrainStamp);
            this._log.insert_log(Userdata.Aminname,Userdata.name, "WEB", "DeleteStamp", "Delete " + model.stampcode, "5", model.stampcode, "", "", ip,Userdata.AdminLevel.ToString(), DateTime.Now.ToString(), "", "");

            List<ActiveStampModel> list = new List<ActiveStampModel>();
            list = this.stampservice.ActiveStampList(Userdata.CompanyID, Userdata.DeptID,Userdata.AdminLevel.ToString());
            return Ok(new { data_active_stamp = list });
        }
        [Route("stamp/api/GetMessageWeb")]
        [HttpGet]
        public List<MessageWebModel> GetMessageWeb()
        {
            List<MessageWebModel> list = new List<MessageWebModel>();
            list = this.stampservice.get_MessageWeb();
            return list;
        }



    }
}
