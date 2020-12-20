using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Parking.interfaces;
using Parking.Models;
using Parking.Models.Auth;
using Parking.Models.Member;
using Parking.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Parking.Controllers
{
    [Authorize]
    public class MemberController : ApiController
    {
        private GetDataAPI getAPI = new GetDataAPI();
        private IMember _memberService = new MemberService();
        [Route("api/stamp/memberlist")]
        [HttpGet]
        public List<MemberModel> Member(int cardType)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];
            var member_list = this._memberService.memberlist(cardType,Userdata.CompanyID,Userdata.DeptID);
            return member_list;
        }
        [Route("api/stamp/MemberTransection")]
        [HttpGet]
        public List<memberTranList> MemberTransection( string depId, string CardType, string CscMain, string startdate, string end_date,string in_out)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var memberTranList = this._memberService.getMemberTranList(Userdata.CompanyID, depId == null ? "": depId, CardType == null ? "": CardType, CscMain == null ? "" : CscMain, startdate , end_date, in_out);
            return memberTranList;
        }
        [Route("api/stamp/RequireChangeMember")]
        [HttpGet]
        public List<TranRequireMember> RequireChangeMember()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<TranRequireMember> list = new List<TranRequireMember>();
            list = this._memberService.getTranRequireMember(Userdata.CompanyID);
            return list;
        }
        [Route("api/stamp/AddRequireMember")]
        [HttpPost]
        public IHttpActionResult AddRequireMember(RequireMember data_RequireMember)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            string reqNo = this._memberService.createNo1(Userdata.CompanyID);
            string result = this._memberService.insert_RequestMember(
                reqNo,
               Userdata.CompanyID,
                1,
                data_RequireMember.name,
                data_RequireMember.lastName,
                data_RequireMember.carType,
                Convert.ToInt32(data_RequireMember.Contacttype),
                Convert.ToInt32(data_RequireMember.payment),
                data_RequireMember.licenseplate,
                data_RequireMember.Model,
                data_RequireMember.Color,
                data_RequireMember.licenseplate1,
                data_RequireMember.Model1,
                data_RequireMember.Color1,
                data_RequireMember.licenseplate2,
                data_RequireMember.Model2,
                data_RequireMember.Color2,
                Convert.ToDateTime(data_RequireMember.firstday),
              Userdata.Aminname,
                data_RequireMember.PhoneNumber);
            return Ok(new { Mes="Ok", reqNo= reqNo });
        }
        [Route("api/stamp/RequireChangeMember")]
        [HttpPost]
        public IHttpActionResult RequireChangeMember(CheangeMemberModel data)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            string reqNo = this._memberService.createNo1(Userdata.CompanyID);
            string result = this._memberService.RequestCheangMember(
                   reqNo,
                  Userdata.CompanyID,
                   "2",
                   data.memberCode,
                   data.name,
                   data.lastName,
                   data.cardtype,
                   data.check_cheangcontacType,
                   data.New_Contacttype,
                   data.Contacttype,
                   data.payment,
                   data.check_licensep,
                   data.new_licenseplate,
                   data.new_Model,
                   data.new_CarColor,
                   data.new_licenseplate1,
                   data.new_Model1,
                   data.new_CarColor1,
                   data.new_licenseplate2,
                   data.new_Model2,
                   data.new_CarColor2,
                   data.licenseplate,
                   data.Model,
                   data.CarColor,
                   data.licenseplate1,
                   data.Model1,
                   data.CarColor1,
                   data.licenseplate2,
                   data.new_Model2,
                   data.CarColor2,
                  data.firstday,
                  Userdata.Aminname,
                   data.New_Name,
                   data.New_LastName,
                   data.Check_cheangName);
            return Ok(new { Mes = "Ok",reqNo = reqNo });
        }
        [Route("api/stamp/RequireCancelMember")]
        [HttpPost]
        public IHttpActionResult RequireCancelMember(CancelMemberModel _model)
        {

            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            string reqNo = this._memberService.createNo1(Userdata.CompanyID);
            string result = this._memberService.CancelMember(reqNo, Userdata.CompanyID, 3, _model.cusNo, _model.name, _model.last_name, _model.card_type, _model.CancelDate,
             Userdata.Aminname, _model.licenplatel, _model.model, _model.car_color, _model.licenplatel1, _model.model1, _model.car_color1, _model.licenplatel2, _model.model2, _model.car_color2);
            return Ok(new { Mes="Ok" , reqNo = reqNo });
        }
        [Route("api/stamp/MemberCompany")]
        [HttpGet]
        public List<MemberCardModel> MemberCompany()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];


            List<MemberCardModel> list = new List<MemberCardModel>();
            list = this._memberService.MemberCompany(Userdata.CompanyID);
            return list;
        }
        [Route("api/stamp/getMemnerDepartmentList")]
        [HttpGet]
        public List<MemberList> getMemnerDepartmentList()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<MemberList> list = new List<MemberList>();
            list = this._memberService.MemberDepartment(Userdata.CompanyID, Userdata.DeptID);
            return list;
        }
        [Route("api/stamp/DepartmentList")]
        [HttpGet]
        public List<DepartmentList> DepartmentList()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<DepartmentList> list = new List<DepartmentList>();
            list = this._memberService.departmentList(Userdata.CompanyID, Userdata.DeptID);
            return list;
        }
        [Route("api/stamp/GetCardTypeList")]
        [HttpGet]
        public List<CardTypeList> GetCardTypeList()
        {
       //  string json =   getAPI.getDataWithToken("http://localhost:8085/api/stamp/GetCardTypeList", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImFkbWluIiwiZXhwIjoiXC9EYXRlKDE1ODY3NjQ0NzMxOTcpXC8ifQ.hQgieTY-mVO1_ZsaP6wI9xKTNQG3-Xzh4PhLDzMWKCc");
            List<CardTypeList> list = new List<CardTypeList>();
            list = this._memberService.cardTypeList();
            return list;
        }
        [Route("api/stamp/GetRequireCarTypeList")]
        [HttpGet]
        public List<RequireCarTypeList> getRequireCarTypeList()
        {
            List<RequireCarTypeList> list = new List<RequireCarTypeList>();
            list = this._memberService.getCarTypeList();
            return list;

        }
        [Route("api/stamp/GetRequirepayment")]
        [HttpGet]
        public List<Requirepayment> getRequirepayment()
        {
            List<Requirepayment> list = new List<Requirepayment>();
            list = this._memberService.getPaymentList();
            return list;
        }

        [Route("api/stamp/GetContacttypeList")]
        [HttpGet]
        public List<RequireContacttype> GetContacttypeList()
        {
            List<RequireContacttype> list = new List<RequireContacttype>();
            list = this._memberService.getContacttypeList();
            return list;
        }


        [Route("api/cdr/uploadfile")]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            UploadFileModel uploadfile = new UploadFileModel();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var reqid = httpRequest.Form["reqId"].ToString();
                var doctype = httpRequest.Form["docType"].ToString();
                var admin_id = httpRequest.Form["sAdmin"].ToString();
                string json_result = "";
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string FileName = postedFile.FileName;
                    string fileContenType = postedFile.ContentType;
                    byte[] fileBytes = new byte[postedFile.ContentLength];
                    postedFile.InputStream.Read(fileBytes, 0, postedFile.ContentLength);
                    byte[] data_file = fileBytes;

                    //uploadfile.PathFile = data_file;

                     var filePath = HttpContext.Current.Server.MapPath("~/Content/DocumentUpload/" +DateTime.Now.ToString("ddMMyyyyhhmmss")+ postedFile.FileName);
                     postedFile.SaveAs(filePath);
                    //docfiles.Add(filePath);
                    string DOC_Base64 = Convert.ToBase64String(data_file);
                    string result2 = this._memberService.AddUploadDoc(reqid, doctype, reqid + FileName, DOC_Base64, admin_id, filePath);
                    json_result = JsonConvert.SerializeObject(uploadfile);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, json_result);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }


        [Route("api/stamp/GetDocList")]
        [HttpGet]
        public List<DocList> GetDocList(string reqId)
        {
            List<DocList> list = new List<DocList>();
            list =   this._memberService.getDataUpload(reqId);
            return list;
        }


        [Route("api/stamp/SendEmail")]
        [HttpGet]
        public IHttpActionResult SendEmail(string reqId)
        {
            this._memberService.SendEmailUploadFile(reqId);
            return Ok();

        }
        [Route("api/stamp/GetMemberList")]
        [HttpGet]
        public List<Member_List> getMemberList(string type)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<Member_List> list = new List<Member_List>();
            list = this._memberService.member_list(Userdata.CompanyID, type);
            return list;
        }
        [Route("api/stamp/userInfo")]
        [HttpGet]
        public UserinfoModel userInfo(string userid, string Typecard)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            UserinfoModel userinfo = new UserinfoModel();

            userinfo = this._memberService.userinfo(userid, Userdata.CompanyID, Typecard);
            return userinfo;
        }




    }

    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public class UploadFileModel
    {
        public string reqId { get; set; }
        public string DocTypeId { get; set; }
        public HttpPostedFileBase PathFile { get; set; }
    }

}
