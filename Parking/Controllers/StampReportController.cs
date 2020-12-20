using Parking.Service;
using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parking.Models.StampReport;
using Parking.Models.Stamp;
using Parking.Models.Auth;
using System.Web;

namespace Parking.Controllers
{
    [Authorize]
    public class StampReportController : ApiController
    {
        private IStamp _stamp_serview = new StampService();
        private ICompany _company = new CompanyService();
        private IStampReport _stampReport = new StampReportService();

        [Route("api/stamp/stampReport")]
        [HttpGet]
        public List< StampTranModel> StampReport( string start_date, string end_date, string stamp_code , string TernsubCode, string in_out, string stamp_status, string car_type)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.stamp_report(in_out == null ? "" : in_out, stamp_status == null ? "" : stamp_status, car_type == null ? "" : car_type, Userdata.CompanyID, TernsubCode == null ? "":TernsubCode, start_date, end_date, stamp_code == null ? "" : stamp_code);
            return data_stamp;
        }
        [Route("api/stamp/StampReportByCustom")]
        [HttpGet]
        public List<ReportByCustomTran> StampReportByCustom(string start_date, string end_date, string stamp_code, string ternsubcode, string in_out, string stamp_status, string car_type, string custom)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.stamp_by_custom(in_out == null ? "" : in_out, stamp_code == null ? "" : stamp_code, stamp_status == null ? "" : stamp_code, car_type == null ? "" : car_type, Userdata.CompanyID, ternsubcode == null ? "" : ternsubcode, custom == null ? "" : custom, start_date, end_date);
            return data_stamp;
        }
        [Route("api/stamp/StampReportByStamp")]
        [HttpGet]
        public List<StampByStampList> StampReportByStamp( string start_date, string end_date, string ternsubcode, string stamp_code , string status_stamp)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.stamp_by_stamp(start_date, end_date, Userdata.CompanyID, ternsubcode, stamp_code == null ? "":stamp_code, status_stamp == null ? "" : status_stamp, Userdata.AdminLevel.ToString());
            return data_stamp;
        }

        [Route("api/stamp/StampReportByUser")]
        [HttpGet]
        public List<StampByUserTran> StampReportByUser(string start_date, string end_date, string stamp_code, string ternsubcode, string admin_name)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.stamp_by_user(start_date, end_date, Userdata.CompanyID, ternsubcode, admin_name == null ?"":admin_name, stamp_code == null ?"": stamp_code);
            return data_stamp;
        }
        [Route("api/stamp/StampReportByDepartment")]
        [HttpPost]
        public List<stamp_report_department_tran> StampReportByDepartment(DepartmentTranModel data_model)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.GetSummaryTernnent(Userdata.CompanyID,Userdata.DeptID, data_model.car_type, data_model.start_date, data_model.end_date);
            return data_stamp;
        }

        [Route("api/stamp/ReportSummaryByStamp")]
        [HttpGet]
        public List<SummaryByStampTran> SummaryByStamp(string start_date, string end_date, string stamp_code, string car_type)
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            var data_stamp = this._stampReport.GetSummaryByStamp(Userdata.CompanyID, start_date, end_date, stamp_code == null ? "" : stamp_code, car_type == null ? "": car_type);
            return data_stamp;
        }

        [Route("api/stamp/stampCodeAll")]
        [HttpGet]
        public List<stampCodeList> stampCodeAll()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<stampCodeList> list = new List<stampCodeList>();
            list = this._stamp_serview.stamp_code_all(Userdata.CompanyID);
            return list;
        }
        [Route("api/stamp/GetDepartmentlist")]
        [HttpGet]
        public List<CompanyModel> GetDepartmentlist()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<CompanyModel> list = new List<CompanyModel>();
            list = this._company.CheckLevelCompany(Userdata.CompanyID);
            return list;
        }
        [Route("api/stamp/GetCustomList")]
        [HttpGet]
        public List<CustomModel> GetCustomList()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<CustomModel> list = new List<CustomModel>();
            list = this._stamp_serview.custom_stamp(Userdata.CompanyID, Userdata.DeptID);

            return list;
        }

        [Route("api/stamp/admin_list")]
        [HttpGet]
        public List<AdminModel> admin_list()
        {
            HttpContext context = HttpContext.Current;
            var Userdata = (UserLoginModel)context.Items["user_data"];

            List<AdminModel> list = new List<AdminModel>();
            list = this._stamp_serview.admin_list(Userdata.CompanyID, Userdata.AdminLevel.ToString());
            return list;
        }
    }
}
