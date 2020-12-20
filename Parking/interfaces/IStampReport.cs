using Parking.Models.StampReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Models.Member;

namespace Parking.interfaces
{
    interface IStampReport
    {
        List<in_out> in_out_list();
        List<stamp_status> stamp_status();
        List<CardType> CarTypeList();
        List<StampTranModel> stamp_report(string CompleteFlag, string StampStatus, string CardType, string TernCode, string TerSubCode, string strdate, string enddate, string stamp_code);
        List<ReportByCustomTran> stamp_by_custom(string CompleteFlag, string StampCode, string StampStatus, string CarType, string Terncode, string TernSubCode, string custom_stamp, string strdate, string enddate);
        List<StampByStampList> stamp_by_stamp(string strdate, string enddate, string terncode, string ternsubcode, string stamp_code, string stamp_status, string admin_level);
        List<StampByUserTran> stamp_by_user(string start_date, string end_date, string tercode, string ternsubcode, string user_name, string stamp_code);
        List<stamp_report_department_tran> GetSummaryTernnent(string terncode, string ternsubcode, string car_type, DateTime start_date, DateTime end_date);
        List<SummaryByStampTran> GetSummaryByStamp(string terncode, string start_date, string end_date, string stamp_code, string car_type);
    }
}
