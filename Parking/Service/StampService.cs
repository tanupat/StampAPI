using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Stamp;
using Parking.Models;
using System.Data;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using Parking.Entity;
using Parking.Models.StampReport;

namespace Parking.Service
{
    public class StampService : IStamp
    {
        private clsDatabase db = new clsDatabase();
        WarpsystemEntities _dbWarp = new WarpsystemEntities();

        public bool CheckTheStampRepeat(string stampCode, string inOutTran)
        {

            string sql = "select count(InOutTranstamp_ID) as stamp_count from  pkinouttranstamp where InOutTran_ID = '" + inOutTran+"' and StampCode = '"+stampCode+"' ";
             var data_count = db.QueryDataTable(sql);
            if (Convert.ToInt32(data_count.Rows[0]["stamp_count"]) > 0)
            {
                return true;
            }
            else {
                return false;
            }

           
        }

        public TranVisitorModel GetVisitorInOut(string visitorID)
        {
            try {
                TranVisitorModel tranVisitor = new TranVisitorModel();
                DataTable dt_Pkaip = new DataTable();

      
                    DataTable dt1 = new DataTable();
               
                    string sql = " select InOutTran_ID,CarID,CscMain_ID,Indate ";
                    sql = sql + " from PkInoutTran ";
                    sql = sql + " where CscMain_ID = '" + visitorID + "'  and CompleteFlag = 0  ";
                    sql = sql + " order by Indate ";
                    dt1 = db.QueryDataTable(sql);
                    tranVisitor = (from c in dt1.AsEnumerable()
                                   select new TranVisitorModel
                                   {
                                       InOutTran_ID = c["InOutTran_ID"].ToString(),
                                       CarID = c["CarID"].ToString(),
                                       CscMain_ID = c["CscMain_ID"].ToString(),
                                       Indate = Convert.ToDateTime(c["Indate"])
                                   }).SingleOrDefault();
           
                return tranVisitor;

            } catch (Exception ex) {
                throw ex;
            }
          


        }

        public StampModel InOutTranDetail(string visitorId, string terncode, string ternsubcode, string adminlevel)
        {
            try {

                DataTable dt = new DataTable();
                StampModel _stampModel = new StampModel();
                string sql = " select InOutTran_ID,CarID,CscMain_ID,Indate,Picin1,Picin2,Picin3 ";
                sql = sql + " from PkInoutTran ";
                sql = sql + " where CscMain_ID = '" + visitorId + "'  and CompleteFlag = 0  ";
                sql = sql + " order by Indate ";
                dt = db.QueryDataTable(sql);
                var data_input = (from c in dt.AsEnumerable() select new {
                    inoutTrainID = c["InOutTran_ID"].ToString(),
                    license_plate = c["CarID"].ToString(),
                    Time_IN = c["Indate"].ToString(),
                    VisitorID = c["CscMain_ID"].ToString(),
                    PicIn1 = c["Picin1"].ToString(),
                    PicIn2 = c["Picin2"].ToString(),
                    PicIn3 = c["Picin3"].ToString()
                }).SingleOrDefault();
                if (data_input == null) {
                    return null;
                }
                _stampModel.license_plate = data_input.license_plate;
                _stampModel.inoutTrainID = data_input.inoutTrainID;
                _stampModel.Time_IN = Convert.ToDateTime(data_input.Time_IN);
                _stampModel.VisitorID = data_input.VisitorID;
                _stampModel.TotalTime = TotalTime(Convert.ToDateTime(data_input.Time_IN));
                _stampModel.PicIn1 = getImage(ConfigurationManager.AppSettings["PathImageCar"].ToString() + data_input.PicIn1);
                _stampModel.PicIn2 = getImage(ConfigurationManager.AppSettings["PathImageCar"].ToString() + data_input.PicIn2);
                _stampModel.PicIn3 = getImage(ConfigurationManager.AppSettings["PathImageCar"].ToString() + data_input.PicIn3);

                DataTable dt_inoutTranStamp = new DataTable();
                string sql_inouttranStamp = "select ";
                sql_inouttranStamp += "  ts.InOutTranstamp_ID,";
                sql_inouttranStamp += "  ts.datetimestamp, ";
                sql_inouttranStamp += "  ts.StampCode + ' ' + s.ZDesc as Stamp,";
                sql_inouttranStamp += "  ts.Active1, ";
                sql_inouttranStamp += "  d.Zdesc as companyname , ";
                sql_inouttranStamp += "  ts.Terncode,";
                sql_inouttranStamp += "  ts.Ternsubcode ";
                sql_inouttranStamp += "  from pkinouttranstamp Ts ";
                sql_inouttranStamp += "  left join PkDepartments d on ts.Terncode = d.CompanyID and ts.Ternsubcode = d.DeptID ";
                sql_inouttranStamp += "  left join PkStamp s on ts.StampCode = s.StampCode ";
                sql_inouttranStamp += "  where ts.InOutTran_ID = '" + data_input.inoutTrainID + "' order by ts.datetimestamp desc ";
                dt_inoutTranStamp = this.db.QueryDataTable(sql_inouttranStamp);

                var data_inoutTrainStamp = (from c in dt_inoutTranStamp.AsEnumerable()
                                            select new historyStamp
                                            {
                                                Calculation = Convert.ToInt32(c["Active1"]),
                                                Company = c["companyname"].ToString(),
                                                DateTimeStamp = Convert.ToDateTime(c["datetimestamp"]),
                                                StampCode = c["Stamp"].ToString(),
                                                ternCode = c["Terncode"].ToString(),
                                                ternsubCode = c["Ternsubcode"].ToString(),
                                                InOutTranstamp_ID = c["InOutTranstamp_ID"].ToString()
                                            }).OrderByDescending(c => c.DateTimeStamp).ToList();


                _stampModel.StampCodeList = StampCodeList(visitorId, terncode, ternsubcode, adminlevel);
                _stampModel.historyStamp_list = data_inoutTrainStamp;


                return _stampModel;



            }
            catch (Exception ex) {
                throw ex;
            }
       
        }

        public List<stampCodeList> StampCodeList(string visitorId, string terncode, string ternsubcode, string adminLevel)
        {
            List<stampCodeList> list = new List<stampCodeList>();
            DataTable dt = new DataTable();

            SqlParameterCollection parameter = new SqlCommand().Parameters;
            parameter.Add("@visitorId", SqlDbType.VarChar).Value = visitorId;
            parameter.Add("@ternCode", SqlDbType.VarChar).Value = terncode;
            parameter.Add("@terSubCode", SqlDbType.VarChar).Value = ternsubcode;
            parameter.Add("@adminLevel_Id", SqlDbType.VarChar).Value = adminLevel;

            dt = this.db.StoreQuery("PkStampCodeList", parameter);


               list = (from c in dt.AsEnumerable() select new stampCodeList {
                      stampcode = c["StampCode"].ToString(),
                      stampCodeName = c["StampCode"].ToString()+" "+c["ZDesc"].ToString()
                }).ToList();

      

            return list;
        }


        public string TotalTime(DateTime startdate)
        {
            DateTime t1 = DateTime.Now;
            DateTime t2 = startdate; //yesterday
            TimeSpan ts = t1.Subtract(t2);
            return ts.Days.ToString() + "Days " + ts.Hours + "  Hour  " + ts.Minutes + "Minute";
        }

        public void insertStamp(string stampCode, string inout_tran, string ternCode, string ternsubCode, int? level, string custom, string admin_name, string custom_stamp) {
            SqlParameterCollection parameter = new SqlCommand().Parameters;
            parameter.Add("@stampCode", SqlDbType.VarChar).Value = stampCode;
            parameter.Add("@inout_tran", SqlDbType.VarChar).Value = inout_tran;
            parameter.Add("@ternCode", SqlDbType.VarChar).Value = ternCode;
            parameter.Add("@ternsubCode", SqlDbType.VarChar).Value = ternsubCode;
            parameter.Add("@custom", SqlDbType.NVarChar).Value = custom;
            parameter.Add("@admin_name", SqlDbType.NVarChar).Value = admin_name;
            parameter.Add("@level", SqlDbType.Int).Value = level; 
            parameter.Add("@custom_stamp", SqlDbType.NVarChar).Value = custom_stamp == null ? "":custom_stamp;
           
            this.db.StoreQuery("StampProsess", parameter);
        }

        private string getImage(string Path)
        {
            if (File.Exists(Path))
            {
                using (Image image = Image.FromFile(Path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return "data:image/jpg;base64," + base64String;
                    }
                }
            }
            else
            {
                return "data:image/jpg;base64,";
            }

        }

        public ChangeStampModel CheangeStamp(string ternCode, string ternSubCode, string inoutTrainStamp, string visitor_id, int? adminLevel)
        {
            ChangeStampModel model = new ChangeStampModel();
            DataTable data_card_type = new DataTable();
            List<stampCodeList> stampcodelist = new List<stampCodeList>();
            string CardType = "";
            SqlParameterCollection parameter1 = new SqlCommand().Parameters;
            parameter1.Add("@inoutTranstamp", SqlDbType.NVarChar).Value = inoutTrainStamp;
            var data_ChangeStamp = this.db.StoreQuery("Change_Stamp_Detail", parameter1);
            string sql_cardType = "select Cartype from PkCard where CscMain_ID = '"+visitor_id+"' ";
             data_card_type =  db.QueryDataTable(sql_cardType);
            CardType = data_card_type.Rows[0]["Cartype"].ToString();
            string sql_StampCodeList = "SELECT  StampCode, StampCode+' '+ZDesc as StampDese FROM [dbo].[PkStamp] where Cartype = '"+CardType+"' and TernCode = '"+ternCode+"' and TernSubCode = '"+ternSubCode+"' and admin_level_id >= "+adminLevel+" ";
             var data_StampCodeList =   db.QueryDataTable(sql_StampCodeList);
            stampcodelist = (from c in data_StampCodeList.AsEnumerable() select new stampCodeList {
                 stampcode = c["StampCode"].ToString(),
                  stampCodeName = c["StampDese"].ToString()
            }).ToList();
            model.stampCodeList = stampcodelist;
            model.inoutTranID = data_ChangeStamp.Rows[0]["InOutTran_ID"].ToString();
            model.inoutTrainStampID = data_ChangeStamp.Rows[0]["InOutTranstamp_ID"].ToString();
            model.DateTimeStamp = Convert.ToDateTime(data_ChangeStamp.Rows[0]["datetimestamp"]);
            model.stampCode = data_ChangeStamp.Rows[0]["StampCode"].ToString();
            model.stampCodeOld = data_ChangeStamp.Rows[0]["StampCode"].ToString();
            model.VisitorId = visitor_id;
            model.licensePlate = data_ChangeStamp.Rows[0]["CarID"].ToString();

            return model;
        }

        public List<ActiveStampModel> ActiveStampList(string terncode, string tersubcode, string adminLevel)
        {
            DataTable dt_active_stamp = new DataTable();
            List<ActiveStampModel> active_stamp_list = new List<ActiveStampModel>();
            SqlParameterCollection parameter1 = new SqlCommand().Parameters;
            parameter1.Add("@ternCode", SqlDbType.VarChar).Value = terncode;
            parameter1.Add("@terSubCode", SqlDbType.VarChar).Value = tersubcode;
            parameter1.Add("@adminLevel", SqlDbType.VarChar).Value = adminLevel;
            dt_active_stamp = db.StoreQuery("ActiveStampList", parameter1);
            active_stamp_list = (from c in dt_active_stamp.AsEnumerable() select new ActiveStampModel {
                 InoutTrainStamp = c["InOutTranstamp_ID"].ToString(),
                 TimeStamp = Convert.ToDateTime( c["datetimestamp"]),
                 license_plate = c["CarID"].ToString(),
                 StampCode = c["StampCode"].ToString(),
                 visitor_id = c["CscMain_ID"].ToString()
            }).ToList();
            return active_stamp_list;
        }

     

        public string UpdateStamp(string stampCode, string inoutTranID, string inoutTranStamp)
        {
            string mes = "";
            DataTable dt_Single_stamp = new DataTable();
            DataTable dt_pkinouttran = new DataTable();
            DataTable dt_stamp = new DataTable();
            string sql_PkStamp = "select * from PkStamp t1 where t1.StampCode = '"+stampCode+"' and t1.SingleStampFlg = 1 ";
            string sql_pkinouttranstamp = "select *  from pkinouttranstamp t2 where t2.InOutTran_ID = '"+inoutTranID+"' and t2.SingleStampFlg = 1"; 
            string sql_stamp = "select * from pkinouttranstamp t3 where t3.InOutTran_ID = '"+inoutTranID+"' and t3.StampCode = '"+stampCode+"' ";

            dt_Single_stamp = db.QueryDataTable(sql_PkStamp);
            dt_pkinouttran = db.QueryDataTable(sql_pkinouttranstamp);
            dt_stamp = db.QueryDataTable(sql_stamp);

            if (dt_Single_stamp.Rows.Count > 0 & dt_pkinouttran.Rows.Count > 0)
            {
                mes = "HaveSingleStamp";
                return mes;
            }
             if (dt_stamp.Rows.Count > 0)
            {
                mes = "StampDuplicate";
                return mes;
            }

            SqlParameterCollection parameter1 = new SqlCommand().Parameters;
            parameter1.Add("@stampCode", SqlDbType.VarChar).Value = stampCode;
            parameter1.Add("@inouttranID", SqlDbType.VarChar).Value = inoutTranID;
            parameter1.Add("@inoutTranStampID", SqlDbType.VarChar).Value = inoutTranStamp;
            db.QueryExecuteNonQueryStor("ChangeStampProsess", parameter1);
            mes = "ok";
            return mes;
        }

        public void DeleteStamp(string stampcode, string inoutTrainStamp)
        {
            try
            {
                DataTable dt_inoutTranId = new DataTable();
                SqlParameterCollection parameter = new SqlCommand().Parameters;
                string sql_check_inoutID = "select InOutTran_ID from  pkinouttranstamp where InOutTranstamp_ID = '" + inoutTrainStamp + "' ";
                dt_inoutTranId = db.QueryDataTable(sql_check_inoutID);
                if (dt_inoutTranId.Rows.Count > 0)
                {
                    string inoutTranId = dt_inoutTranId.Rows[0]["InOutTran_ID"].ToString();
                    parameter.Add("@stampcode", SqlDbType.VarChar).Value = stampcode;
                    parameter.Add("@inouttranstamp", SqlDbType.VarChar).Value = inoutTrainStamp;
                    parameter.Add("@inouttran", SqlDbType.VarChar).Value = inoutTranId;
                    db.QueryExecuteNonQueryStor("delete_stamp", parameter);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
           

            


        }

        public List<stampCodeList> stamp_code_all(string terncode)
        {
            List<stampCodeList> list_stamp_code = new List<stampCodeList>();
            list_stamp_code = this._dbWarp.PkStamps.Where(c => c.TernCode == terncode).Select(x => new stampCodeList
            {
                stampcode = x.StampCode,
                stampCodeName = x.StampCode + " " + x.ZDesc
            }).ToList();
            return list_stamp_code;
        }

        public List<CustomModel> custom_stamp(string tercode, string ternsubcode)
        {
            List<CustomModel> list = new List<CustomModel>();
            DataTable dt = new DataTable();
            string sql = " select s.custom_stamp  from pkinouttranstamp s " +
                         "  where s.Terncode = '" + tercode + "' AND S.Ternsubcode = '" + ternsubcode + "' " +
                        "   AND S.Ternsubcode is not null and s.custom_stamp is not null and len(s.custom_stamp) > 0 and s.custom_stamp not in('null') group by s.custom_stamp ";

            dt = this.db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new CustomModel
                    {
                        custom_stamp = c["custom_stamp"].ToString()
                    }).ToList();

            return list;


        }
        public List<AdminModel> admin_list(string ternCode, string adminlevel)
        {
            List<AdminModel> list = new List<AdminModel>();
            DataTable dt = new DataTable();
            string sql = " select name from  PkAdminweb "
                  + " where PkAdminweb.Terncode = '" + ternCode + "'  and admin_level_id >= " + adminlevel + "";
            dt = this.db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new AdminModel
                    {
                        admin_name = c["name"].ToString()
                    }).ToList();
            return list;
        }

        public List<MessageWebModel> get_MessageWeb()
        {
            List<MessageWebModel> list = new List<MessageWebModel>();
            list = this._dbWarp.GetMessageWeb().Select(c => new MessageWebModel { pic1 = c.pic1, Message = c.Message, Subject1 = c.Subject1 }).ToList();
            return list;
        }
    }
}