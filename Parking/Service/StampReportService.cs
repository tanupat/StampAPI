using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Member;
using Parking.Models.StampReport;
using Parking.Entity;
using Parking.Models;
using System.Data;

namespace Parking.Service
{
    public class StampReportService : IStampReport
    {
        clsDatabase _db = new clsDatabase();
        WarpsystemEntities _db_stamp = new WarpsystemEntities();
        public List<CardType> CarTypeList()
        {
            List<CardType> carttypelist = new List<CardType>();

            carttypelist.Add(new CardType
            {
                CardTypeId = 1,
                CardTypeName = "Car"
            });

            carttypelist.Add(new CardType
            {
                CardTypeId = 2,
                CardTypeName = "motorcycle"
            });

            return carttypelist;
        }

        public List<SummaryByStampTran> GetSummaryByStamp(string terncode, string start_date, string end_date, string stamp_code, string car_type)
        {
            DataTable dt = new DataTable();
            List<SummaryByStampTran> list = new List<SummaryByStampTran>();
            string sql = "";
            int function = Convert.ToInt32(car_type);

            switch (function)
            {
                case 0:
                    sql = " SELECT terncode, zdesc, dateout1, COUNT(terncode) as ccount, SUM(feetenant) as totalfee, StampCode  FROM Vsummarytenantbystamp " +
                          " where terncode='" + terncode + "' and (  CONVERT(varchar(10),dateout1,120)  between '" + start_date + "' and '" + end_date + "')and stampcode like '%" + stamp_code + "%'   group by terncode,zdesc,dateout1,StampCode  order by terncode,dateout1";
                    break;
                case 1:
                    sql = " SELECT terncode,zdesc,dateout1,COUNT(terncode) as ccount,SUM(feetenant) as totalfee ,StampCode  FROM Vsummarytenantbystamp_car " +
                         " where terncode='" + terncode + "'   and ( CONVERT(varchar(10),dateout1,120) between '" + start_date + "' and '" + end_date + "')and stampcode like '%" + stamp_code + "%'   group by terncode,zdesc,dateout1,StampCode  order by terncode,dateout1";
                    break;
                case 2:
                    sql = " SELECT terncode,zdesc,dateout1,COUNT(terncode) as ccount,SUM(feetenant) as totalfee ,StampCode  FROM Vsummarytenantbystamp_motor " +
                                " where terncode='" + terncode + "'   and ( CONVERT(varchar(10),dateout1,120) between '" + start_date + "' and '" + end_date + "')and stampcode like '%" + stamp_code + "%'   group by terncode,zdesc,dateout1,StampCode  order by terncode,dateout1";
                    break;

            }

            dt = this._db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new SummaryByStampTran
                    {
                        date_count = Convert.ToDateTime(c["dateout1"]).ToString("dd-MMM-yyyy"),
                        stamp_code = c["StampCode"].ToString(),
                        stamp_count = c["ccount"].ToString(),
                        toltal_amont = Convert.ToDecimal(c["totalfee"]).ToString("#.##")
                    }).ToList();

            return list;
        }

        public List<stamp_report_department_tran> GetSummaryTernnent(string terncode, string ternsubcode, string car_type, DateTime start_date, DateTime end_date)
        {
            List<stamp_report_department_tran> list = new List<stamp_report_department_tran>();
            list = this._db_stamp.Pk_GetSummaryTernnent(terncode, ternsubcode, int.Parse(car_type), start_date, end_date)
                .Select(c => new stamp_report_department_tran { department = c.zdesc, count = Convert.ToInt32(c.ccount), amount = Convert.ToDecimal(c.totalfee).ToString("#.##"), date_count = Convert.ToDateTime(c.dateout1) }).ToList();
            return list;
        }

        public List<in_out> in_out_list()
        {
            List<in_out> list = new List<in_out>();
            list.Add(new in_out
            {
                in_out_id = "1",
                inout = "OUT"

            });
            list.Add(new in_out
            {
                in_out_id = "0",
                inout = "in"

            });
            return list;
        }

        public List<ReportByCustomTran> stamp_by_custom(string CompleteFlag, string StampCode, string StampStatus, string CarType, string Terncode, string TernSubCode, string custom_stamp, string strdate, string enddate)
        {
            List<ReportByCustomTran> list = new List<ReportByCustomTran>();
            DataTable dt = new DataTable();
            string sql =
                "  SELECT pkinouttranstamp.InOutTran_ID," +
                "  pkinouttranstamp.datetimestamp," +
                "  PkInoutTran.CscMain_ID," +
                "  PkInoutTran.CarID," +
                "  pkinouttranstamp.StampCode," +
                "  pkinouttranstamp.InOutTranstamp_ID," +
                "  PkInoutTran.Indate," +
                "  PkInoutTran.OutDate," +
                "  pkinouttranstamp.adminname," +
                "  pkinouttranstamp.Active1, " +
                "  (case when  pkinouttranstamp.custom_stamp is null then '' else  pkinouttranstamp.custom_stamp end) as custom_stamp ," +
                "  pkinouttranstamp.FeeTenant,PkInoutTran.Hourtotal, " +
                "  RIGHT('0' + CAST((PkInoutTran.HourTotal / 60) % 60 AS VARCHAR),2) + ':' +RIGHT('0' + CAST(PkInoutTran.HourTotal % 60 AS VARCHAR),2) as Hour_" +
                "  FROM dbo.PkInoutTran LEFT OUTER JOIN  dbo.pkinouttranstamp " +
                "  ON dbo.PkInoutTran.InOutTran_ID = dbo.pkinouttranstamp.InOutTran_ID LEFT OUTER JOIN  dbo.PkCardType " +
                "  ON dbo.PkInoutTran.Typecard = dbo.PkCardType.CardType_Id LEFT OUTER JOIN  dbo.PkDepartments " +
                "  ON dbo.pkinouttranstamp.Terncode = dbo.PkDepartments.Terncode " +
                "  WHERE (dbo.PkInoutTran.CompleteFlag like '%" + CompleteFlag + "%')  and pkinouttranstamp.StampCode like'%" + StampCode + "%' AND (dbo.pkinouttranstamp.Active1 like '%" + StampStatus + "%' OR dbo.pkinouttranstamp.Active1 IS NULL) " +
                "  AND (dbo.PkCardType.cartype like '%" + CarType + "%') AND (dbo.PkCardType.cashpay = 1) " +
                "  AND ( dbo.pkinouttranstamp.Terncode = '" + Terncode + "' " +
                "  and pkinouttranstamp.TernSubCode like '%" + TernSubCode + "%'  ) " +
                "  AND (dbo.pkinouttranstamp.Terncode IS NOT NULL) " +
                "  and pkinouttranstamp.custom_stamp like '%" + custom_stamp + "%' " +
                "  and CONVERT(varchar(10), dbo.pkinouttranstamp.datetimestamp,120) between '" + strdate + "' and  '" + enddate + "' " +
                "  ORDER BY dbo.pkinouttranstamp.Terncode, dbo.PkInoutTran.DateOut1 ";

            dt = this._db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new ReportByCustomTran
                    {
                        date_time_stamp = c["datetimestamp"].ToString() == "" ? "-" : Convert.ToDateTime(c["datetimestamp"]).ToString("yyyy-MM-dd hh:mm"),
                        visitor_id = c["CscMain_ID"].ToString(),
                        license_plate = c["CarID"].ToString(),
                        stamp_code = c["StampCode"].ToString(),
                        date_in = c["Indate"].ToString() == "" ? "-" : Convert.ToDateTime(c["Indate"]).ToString("yyyy-MM-dd hh:mm"),
                        date_out = c["OutDate"].ToString() == "" ? "-" : Convert.ToDateTime(c["OutDate"]).ToString("yyyy-MM-dd hh:mm"),
                        active = c["Active1"].ToString() == "0" ? "Active" : c["Active1"].ToString() == "1" ? "not Active" : "Unusual",
                        admin_name = c["adminname"].ToString(),
                        amount = Convert.ToDecimal(c["FeeTenant"]).ToString("###,###"),
                        custom = c["custom_stamp"].ToString(),
                        total_host = c["Hour_"].ToString()
                    }).ToList();
            return list;
        }

        public List<StampByStampList> stamp_by_stamp(string strdate, string enddate, string terncode, string ternsubcode, string stamp_code, string stamp_status, string admin_level)
        {

            List<StampByStampList> list = new List<StampByStampList>();
            DataTable dt = new DataTable();
            string sql = "select CONVERT(varchar(20), pkinouttranstamp.datetimestamp,13) as datetimestamp, " +
                           " PkInoutTran.CscMain_ID, " +
                           " PkInoutTran.CarID, " +
                           " pkinouttranstamp.adminname, " +
                           " CONVERT(varchar(11), PkInoutTran.DateOut1,13)+' '+ convert(varchar, PkInoutTran.TimeOut1, 8)  as DateOut1, " +
                           " PkInoutTran.TimeOut1, " +
                           " pkinouttranstamp.StampCode, " +
                           "  CONVERT(varchar(11), PkInoutTran.DateIn1,13)+' '+ convert(varchar, PkInoutTran.TimeIn1, 8)  as DateIn1, " +
                           " PkInoutTran.TimeIn1, " +
                           " pkinouttranstamp.Active1, " +
                           " pkinouttranstamp.FeeTenant " +
                           " from pkinouttranstamp " +
                           " left join PkInoutTran on pkinouttranstamp.InOutTran_ID = PkInoutTran.InOutTran_ID " +
                           " where CONVERT(varchar(10), PkInoutTran.DateOut1,120) between '" + Convert.ToDateTime(strdate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd") + " ' " +
                           " and pkinouttranstamp.Terncode = '" + terncode + "' " +
                           " and pkinouttranstamp.Ternsubcode like '%" + ternsubcode + "%' " +
                           " and pkinouttranstamp.StampCode like '%" + stamp_code + "%' " +
                           " and pkinouttranstamp.Active1 like '%" + stamp_status + "%' " +
                           "  and pkinouttranstamp.adminlevel >= " + admin_level + " ";
            dt = this._db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new StampByStampList
                    {
                        date_time_stamp = Convert.ToDateTime(c["datetimestamp"]).ToString("yyyy-MM-dd hh:mm:ss"),
                        visitor_id = c["CscMain_ID"].ToString(),
                        licen_plate = c["CarID"].ToString(),
                        admin_name = c["adminname"].ToString(),
                        date_in = Convert.ToDateTime(c["DateIn1"]).ToString("yyyy-MM-dd hh:mm:ss"),
                        date_out = c["DateOut1"].ToString() == "" ? "-" : Convert.ToDateTime(c["DateOut1"]).ToString("yyyy-MM-dd hh:mm:ss"),
                        amount = Convert.ToDecimal(c["FeeTenant"]).ToString("###,###"),
                        stamp_code = c["StampCode"].ToString()
                    }).ToList();

            return list;
        }

        public List<StampByUserTran> stamp_by_user(string start_date, string end_date, string tercode, string ternsubcode, string user_name, string stamp_code)
        {
            DataTable dt = new DataTable();
            List<StampByUserTran> list = new List<StampByUserTran>();
            string sql = " select pkinouttranstamp.datetimestamp,PkInoutTran.CarID,PkInoutTran.CscMain_ID,pkinouttranstamp.adminname,"
                                            + " pkinouttranstamp.StampCode, convert( decimal(5,2), pkinouttranstamp.FeeTenant) as FeeTenant from pkinouttranstamp "
                                            + " left join PkInoutTran on pkinouttranstamp.InOutTran_ID = PkInoutTran.InOutTran_ID "
                                            + " where (pkinouttranstamp.Terncode = '" + tercode + "' and pkinouttranstamp.Ternsubcode like '%" + ternsubcode + "%' ) "
                                            + " and pkinouttranstamp.adminname like '%" + user_name + "%' and pkinouttranstamp.StampCode like '%" + stamp_code + "%'  "
                                            + " and CONVERT(varchar(10), PkInoutTran.DateOut1,120)  between '" + start_date + "' and '" + end_date + "' ";

            dt = this._db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new StampByUserTran
                    {
                        date_time_stamp = Convert.ToDateTime(c["datetimestamp"]).ToString("yyyy-MM-dd hh:mm:ss"),
                        admin_name = c["adminname"].ToString(),
                        amount = c["FeeTenant"].ToString(),
                        license_plate = c["CarID"].ToString(),
                        stamp_code = c["StampCode"].ToString(),
                        visitor_id = c["CscMain_ID"].ToString()
                    }).ToList();

            return list;
        }

        public List<StampTranModel> stamp_report(string CompleteFlag, string StampStatus, string CardType, string TernCode, string TerSubCode, string strdate, string enddate, string stamp_code)
        {
            List<StampTranModel> list = new List<StampTranModel>();
            DataTable dt = new DataTable();

            string sql = " SELECT pkinouttranstamp.InOutTran_ID,"
                        + " pkinouttranstamp.datetimestamp,"
                        + "  PkInoutTran.CscMain_ID,"
                        + "  PkInoutTran.CarID,"
                        + "  pkinouttranstamp.StampCode,"
                        + "  pkinouttranstamp.InOutTranstamp_ID,"
                        + "  PkInoutTran.Indate,"
                        + "  PkInoutTran.OutDate,"
                        + "  pkinouttranstamp.adminname,"
                        + "  pkinouttranstamp.Active1,"
                        + "  pkinouttranstamp.FeeTenant, "
                        + " pkinouttranstamp.Custom,"
                        + " pkinouttranstamp.custom_stamp,"
                        + " PkInoutTran.Hourtotal, "
                        + " RIGHT('0' + CAST((PkInoutTran.HourTotal / 60) % 60 AS VARCHAR),2) + ':' +RIGHT('0' + CAST(PkInoutTran.HourTotal % 60 AS VARCHAR),2) as _Hourtotal "
                        + "  FROM dbo.PkInoutTran LEFT OUTER JOIN " +
                          " dbo.pkinouttranstamp ON dbo.PkInoutTran.InOutTran_ID = dbo.pkinouttranstamp.InOutTran_ID LEFT OUTER JOIN " +
                          " dbo.PkCardType ON dbo.PkInoutTran.Typecard = dbo.PkCardType.CardType_Id LEFT OUTER JOIN " +
                          " dbo.PkDepartments ON dbo.pkinouttranstamp.Terncode = dbo.PkDepartments.Terncode " +
                          " WHERE " +
                          "(dbo.PkInoutTran.CompleteFlag like '%" + CompleteFlag + "%') " +
                          " AND (dbo.pkinouttranstamp.Active1 like '%" + StampStatus + "%' OR dbo.pkinouttranstamp.Active1 IS NULL) " +
                          " AND (dbo.PkCardType.cartype like '%" + CardType + "%') AND (dbo.PkCardType.cashpay = 1)  " +
                          " AND ( dbo.pkinouttranstamp.Terncode = '" + TernCode + "'  and pkinouttranstamp.TernSubCode like '%" + TerSubCode + "%')  " +
                          " AND (dbo.pkinouttranstamp.Terncode IS NOT NULL) " +
                          " and CONVERT(varchar(10),dbo.pkinouttranstamp.datetimestamp,120) between '" + strdate + "' and '" + enddate + "' and pkinouttranstamp.StampCode like '%" + stamp_code + "%' " +
                          " ORDER BY dbo.pkinouttranstamp.Terncode, dbo.PkInoutTran.DateOut1 ";
            dt = this._db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new StampTranModel
                    {
                        date_time_stamp = c["datetimestamp"].ToString().Length == 0 ? "-" : Convert.ToDateTime(c["datetimestamp"]).ToString("yyyy-MM-dd hh:mm"),
                        date_in = c["Indate"].ToString().Length == 0 ? "-" : Convert.ToDateTime(c["Indate"]).ToString("yyyy-MM-dd hh:mm"),
                        date_out = c["OutDate"].ToString().Length == 0 ? "-" : Convert.ToDateTime(c["OutDate"]).ToString("yyyy-MM-dd hh:mm"),
                        stamp_code = c["StampCode"].ToString(),
                        license_plate = c["CarID"].ToString(),
                        visitor_id = c["CscMain_ID"].ToString(),
                        admin_name = c["adminname"].ToString(),
                        active = c["Active1"].ToString() == "0" ? "Active" : c["Active1"].ToString() == "1" ? "not Active" : "Unusual",
                        custom = c["Custom"].ToString(),
                        amount = Convert.ToDecimal(c["FeeTenant"]).ToString("###,###"),
                        Hour_total = c["_Hourtotal"].ToString()
                    }).ToList();

            return list;
        }

        public List<stamp_status> stamp_status()
        {
            List<stamp_status> list = new List<stamp_status>();
            list.Add(new stamp_status
            {
                status_id = 0,
                status_name = "Active Stamp"
            });
            list.Add(new stamp_status
            {
                status_id = 1,
                status_name = " not Active Stamp"
            });
            list.Add(new stamp_status
            {
                status_id = 2,
                status_name = "Unusual Active Stamp"
            });

            return list;
        }
    }
}