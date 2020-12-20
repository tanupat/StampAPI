using Parking.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parking.Models.Member;
using Parking.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace Parking.Service
{
    public class MemberService : IMember
    {
        private clsDatabase db = new clsDatabase();

        public string AddUploadDoc(string No1, string docType, string fileNmae, string image, string updateBy, string PathFile)
        {
           try {

                string sql = "INSERT INTO [dbo].[Pkrequirechangememberdoc] ";
            sql += " ([No1] ";
            sql += ",[Documentype] ";
            sql += ",[filename] ";
            sql += ",[Documentimage] ";
            sql += ",[Last_Upd] ";
            sql += ",[Updateby]";
            sql += ",[pathFile]) ";
            sql += " VALUES  ";
            sql += " ( '" + No1 + "' ";
            sql += " ,'" + docType + "'";
            sql += " , '" + fileNmae + "' ";
            sql += " , '" + image + "' ";
            sql += " , getdate() ";
            sql += " , '" + updateBy + "' ";
            sql += " , '" + PathFile + "' )";

            string result = this.db.QueryExecuteNonQuery(sql);
            return result;
        }
            catch (Exception ex) {
                return ex.Message;
            }
}

        public string CancelMember(string No1, string terncode, int Statustype, string Custno, string Fname, string Lname, string MemberType, string Dateactive, string Updateby, string CarID_Old, string CarModel_Old, string Carcolor_Old, string CarID2_Old, string CarModel2_Old, string Carcolor2_Old, string CarID3_Old, string CarModel3_Old, string Carcolor3_Old)
        {
            try
            {
                SqlParameterCollection parameter = new SqlCommand().Parameters;
                parameter.Add("@No1", SqlDbType.VarChar).Value = No1;
                parameter.Add("@terncode", SqlDbType.VarChar).Value = terncode;
                parameter.Add("@Statustype", SqlDbType.Int).Value = Statustype;
                parameter.Add("@Custno", SqlDbType.VarChar).Value = Custno;
                parameter.Add("@Fname", SqlDbType.NVarChar).Value = Fname;
                parameter.Add("@Lname", SqlDbType.VarChar).Value = Lname;
                parameter.Add("@MemberType", SqlDbType.VarChar).Value = MemberType;
                parameter.Add("@Dateactive", SqlDbType.DateTime).Value = Convert.ToDateTime(Dateactive);
                parameter.Add("@Updateby", SqlDbType.NVarChar).Value = Updateby;
                parameter.Add("@CarID_Old", SqlDbType.NVarChar).Value = CarID_Old;
                parameter.Add("@CarModel_Old", SqlDbType.NVarChar).Value = CarModel_Old;
                parameter.Add("@Carcolor_Old", SqlDbType.NVarChar).Value = CarModel_Old;
                parameter.Add("@CarID2_Old", SqlDbType.NVarChar).Value = CarModel2_Old;
                parameter.Add("@CarModel2_Old", SqlDbType.NVarChar).Value = CarModel2_Old;
                parameter.Add("@Carcolor2_Old", SqlDbType.NVarChar).Value = Carcolor2_Old;
                parameter.Add("@CarID3_Old", SqlDbType.NVarChar).Value = CarID3_Old;
                parameter.Add("@CarModel3_Old", SqlDbType.NVarChar).Value = CarModel3_Old;
                parameter.Add("@Carcolor3_Old", SqlDbType.NVarChar).Value = Carcolor3_Old;
                db.QueryExecuteNonQueryStor("requestCancelMember", parameter);
                return "ok";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CardTypeList> cardTypeList()
        {
            DataTable dt = new DataTable();
            List<CardTypeList> list = new List<CardTypeList>();
            string sql = "select CardType_Id , Zdesc from PkCardType where cashpay = 0 and CardType_Id in(2,4,6)";
            dt = db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new CardTypeList
                    {
                        CardType = c["Zdesc"].ToString(),
                        CardTypeId = c["CardType_Id"].ToString()
                    }).ToList();
            return list;
        }

        public List<CardType> CarTypeList()
        {
            throw new NotImplementedException();
        }

        public string createNo1(string ternCode)
        {
            string sql = "select CONVERT(nvarchar(10), GETDATE(),112)+'" + ternCode + "'+ convert(varchar(10),count(*)+1) as requreId from Pkrequirechangemember";

            string id = this.db.QueryDataTable(sql).Rows[0]["requreId"].ToString();
            return id;
        }

        public List<DepartmentList> departmentList(string Terncode, string TernSubCode)
        {
            DataTable dt = new DataTable();
            List<DepartmentList> list = new List<DepartmentList>();
            string sql = " select DeptName,DeptID from PkDepartments "
                    + " where (CompanyID = '" + Terncode + "' and DeptID = '" + TernSubCode + "') or (CompanyID = '" + Terncode + "' and SupDepID = '" + TernSubCode + "')";

            dt = db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new DepartmentList
                    {
                        DepId = c["DeptID"].ToString(),
                        DepName = c["DeptName"].ToString()
                    }).ToList();
            return list;
        }

        public DocumentDowloadModel Doc_Dowload(string no1)
        {
            DocumentDowloadModel data = new DocumentDowloadModel();
            DataTable dt = new DataTable();
            string sql = "SELECT  [No1],[Zdesc],[pathFile],[Documentimage],[FileName] FROM [dbo].[Pkdocumentdownload] where No1 = " + no1 + " ";
            dt = this.db.QueryDataTable(sql);
            data = (from c in dt.AsEnumerable()
                    select new DocumentDowloadModel
                    {
                        path_dowload = c["pathFile"].ToString(),
                        FileName = c["FileName"].ToString()
                    }).SingleOrDefault();


            return data;
        }

        public List<DocumentDowloadModel> DowloadDocument()
        {
            List<DocumentDowloadModel> list = new List<DocumentDowloadModel>();
            DataTable dt = new DataTable();
            string sql = "SELECT  [No1],[Zdesc],[pathFile],[Documentimage],[FileName] FROM [dbo].[Pkdocumentdownload] ";
            dt = this.db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new DocumentDowloadModel
                    {
                        No1 = Convert.ToInt32(c["No1"]),
                        ducument_name = c["Zdesc"].ToString(),
                        FileName = c["FileName"].ToString(),
                        path_dowload = c["pathFile"].ToString()

                    }).ToList();
            return list;
        }

        public List<RequireCarTypeList> getCarTypeList()
        {
            List<RequireCarTypeList> list = new List<RequireCarTypeList>();

            list.Add(new RequireCarTypeList
            {
                CarTypeID = "C",
                carType = "Car"
            });
            list.Add(new RequireCarTypeList
            {
                CarTypeID = "M",
                carType = "motorcycle"
            });
            return list;
        }

        public List<RequireContacttype> getContacttypeList()
        {
            List<RequireContacttype> list = new List<RequireContacttype>();

            list.Add(new RequireContacttype
            {
                contacttypeId = "0",
                contactype = "Temp"
            });
            list.Add(new RequireContacttype
            {
                contacttypeId = "1",
                contactype = "Fix"
            });
            list.Add(new RequireContacttype
            {
                contacttypeId = "2",
                contactype = "Cir"
            });
            list.Add(new RequireContacttype
            {
                contacttypeId = "3",
                contactype = "Fix pay More"
            });
            list.Add(new RequireContacttype
            {
                contacttypeId = "4",
                contactype = "Cir up Fix"
            });

            return list;
        }

        public List<DocList> getDataUpload(string reqNo)
        {
            DataTable dt = new DataTable();
            List<DocList> doclist = new List<DocList>();

            string sql = " select case Documentype ";
            sql += " when '0' then 'สำเนาประชาชน' ";
            sql += " when '1'  then 'สำเนาทะเบียนรถ' ";
            sql += " when '2' then 'สำเนาใบขับขี่' end as  Documentype, ";
            sql += " filename,Last_Upd from [dbo].[Pkrequirechangememberdoc] where No1 = '" + reqNo + "'";

            dt = this.db.QueryDataTable(sql);

            doclist = (from c in dt.AsEnumerable()
                       select new DocList
                       {
                           docType = c["Documentype"].ToString(),
                           DocName = c["filename"].ToString(),
                           UploadDate = c["Last_Upd"].ToString()
                       }).ToList();

            return doclist;
        }

        public List<DocTypeList> getDocList()
        {
            List<DocTypeList> docTypeList = new List<DocTypeList>();

            docTypeList.Add(new DocTypeList
            {
                docTypeId = "0",
                docType = "สำเนาประชาชน"
            });
            docTypeList.Add(new DocTypeList
            {
                docTypeId = "1",
                docType = "สำเนาทะเบียนรถ"
            });
            docTypeList.Add(new DocTypeList
            {
                docTypeId = "2",
                docType = "สำเนาใบขับขี่"
            });
            return docTypeList;
        }

        public List<memberTranList> getMemberTranList(string terncode, string department, string card_type, string csc_main, string startdate,string enddate,string in_out)
        {
            DataTable dt = new DataTable();
            List<memberTranList> list = new List<memberTranList>();

            string sql_in_out = "";
            if (in_out == "1")
            {
                sql_in_out = " and  PkInoutTran.Outdate is null";
            }
            else if (in_out == "2")
            {
                sql_in_out = " and  PkInoutTran.Outdate is not null";
            }
            else {
                sql_in_out = "";

            }

            string sql = "  select PkInoutTran.CscMain_ID,";
            sql += " PkInoutTran.CarID, ";
            sql += " PkInoutTran.Indate,";
            sql += " PkInoutTran.Outdate,";
            sql += " PkCard.Fname + ' ' + PkCard.Lname as membername ";
            sql += " from PkInoutTran ";
            sql += " left join PkCard on PkInoutTran.Scr_No = PkCard.Scr_No ";
            sql += " where PkCard.CardType = 'M' ";
            sql += " and PkCard.Terncode = '" + terncode + "' ";
            sql += " and PkCard.TernSubCode like '%" + department + "%' ";
            sql += " and PkCard.CardType_ID like '%" + card_type  + "%' ";
            sql += " and PkCard.CscMain_ID like '%" + csc_main  + "%' ";
            sql += " and CONVERT(varchar(10),PkInoutTran.Indate,120)   between '" + startdate + "' and '" +enddate + "'  ";
            sql += sql_in_out;
            sql += " Order by PkInoutTran.Indate asc ";

            dt = this.db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new memberTranList
                    {
                        card_number = c["CscMain_ID"].ToString(),
                        name = c["membername"].ToString(),
                        licensePlate = c["CarID"].ToString(),
                        time_in = Convert.ToDateTime(c["Indate"]).ToString("dd-MMM-yyyy hh:mm:ss"),
                        time_out = c["Outdate"].ToString().Length == 0 ? "NoHaveTimeOut" : Convert.ToDateTime(c["Outdate"]).ToString("dd-MMM-yyyy hh:mm:ss")
                    }).ToList();

            return list;
        }

        public List<Requirepayment> getPaymentList()
        {
            List<Requirepayment> list = new List<Requirepayment>();
            list.Add(new Requirepayment
            {
                paymentId = "1",
                payment = "Company"
            });
            list.Add(new Requirepayment
            {
                paymentId = "2",
                payment = "Employee"
            });
            return list;
        }

        public List<TranRequireMember> getTranRequireMember(string ternCode)
        {
            DataTable dt = new DataTable();
            List<TranRequireMember> list = new List<TranRequireMember>();

            string sql = " select No1,Statustype ,case Statustype when 1 then 'เพิ่ม' when 2 then 'แก้ไข' when 3 then 'ยกเลิก' end as type_status , ";
            sql += " Fname,Lname, case MemberType when 'C' then 'รถยนต์' when 'M' then 'รถจักยานยนต์' end as member_type , case Clearflag when 1 then 'approved' when 0  then 'pending' end as flag ";
            sql += " from Pkrequirechangemember  where terncode = '" + ternCode + "' order by dateissue desc ";

            dt = this.db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new TranRequireMember
                    {
                        action = c["type_status"].ToString(),
                        name = c["Fname"].ToString() + " " + c["Lname"].ToString(),
                        CarType = c["member_type"].ToString(),
                        status = c["flag"].ToString()
                    }).ToList();

            return list;
        }

        public string insert_RequestMember(string No1, string terncode, int? Statustype, string Fname, string Lname, string MemberType, int? Contacttype_New, int? Paytype, string CarID_New, string CarModel_New, string Carcolor_New, string CarID1_New, string CarModel1_New, string Carcolor1_New, string CarID2_New, string CarModel2_New, string Carcolor2_New, DateTime? Dateactive, string Updateby, string Telephone)
        {

            try
            {

            

                SqlParameterCollection parameter = new SqlCommand().Parameters;
                parameter.Add("@No1", SqlDbType.NVarChar).Value = No1;
                parameter.Add("@terncode", SqlDbType.NVarChar).Value = terncode;
                parameter.Add("@Statustype", SqlDbType.NVarChar).Value = Statustype;
                parameter.Add("@Fname", SqlDbType.NVarChar).Value = Fname;
                parameter.Add("@Lname", SqlDbType.NVarChar).Value = Lname;
                parameter.Add("@MemberType", SqlDbType.NVarChar).Value = MemberType;
                parameter.Add("@Contacttype_New", SqlDbType.NVarChar).Value = Contacttype_New;
                parameter.Add("@Paytype", SqlDbType.NVarChar).Value = Paytype;
                parameter.Add("@CarID_New", SqlDbType.NVarChar).Value = CarID_New;
                parameter.Add("@CarModel_New", SqlDbType.NVarChar).Value = CarModel_New;
                parameter.Add("@Carcolor_New", SqlDbType.NVarChar).Value = Carcolor_New;
                parameter.Add("@CarID1_New", SqlDbType.NVarChar).Value = CarID1_New;
                parameter.Add("@CarModel1_New", SqlDbType.NVarChar).Value = CarModel1_New;
                parameter.Add("@Carcolor1_New", SqlDbType.NVarChar).Value = Carcolor1_New;
                parameter.Add("@CarID2_New", SqlDbType.NVarChar).Value = CarID2_New;
                parameter.Add("@CarModel2_New", SqlDbType.NVarChar).Value = CarModel2_New;
                parameter.Add("@Carcolor2_New", SqlDbType.NVarChar).Value = Carcolor2_New;
                parameter.Add("@Dateactive", SqlDbType.DateTime).Value = Convert.ToDateTime(Dateactive);
                parameter.Add("@Updateby", SqlDbType.NVarChar).Value = Updateby;
                parameter.Add("@Telephone", SqlDbType.NVarChar).Value = Telephone;
                db.QueryExecuteNonQueryStor("Add_Requirechangemember", parameter); 

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public List<MemberCardModel> MemberCompany(string ternCode)
        {
            List<MemberCardModel> list = new List<MemberCardModel>();
            DataTable dt = new DataTable();

            string sql = " select CscMain_ID, (Fname+' '+Lname) as Name ,CarId,CarModel,PkCard.Terncode,TernSubCode,PkDepartments.DeptName,CarType from PkCard ";
            sql += "   left join PkDepartments on  PkCard.Terncode = PkDepartments.CompanyID ";
            sql += "    where PkDepartments.Terncode = '" + ternCode + "'  and CardType = 'M' and statuspay  <> 3 order by Fname,CscMain_ID desc  ";
            dt = this.db.QueryDataTable(sql);

            list = (from c in dt.AsEnumerable()
                    select new MemberCardModel
                    {
                        CardNumber = c["CscMain_ID"].ToString(),
                        CompanyName = c["DeptName"].ToString(),
                        FullName = c["Name"].ToString(),
                        Lineceplate = c["CarId"].ToString(),
                        carType = c["CarType"].ToString() == "C" ? "รถยนต์" : "รถจักรยานยนต์"

                    }).ToList();

            return list;
        }

        public List<MemberList> MemberDepartment(string Terncode, string TernSubCode)
        {
            List<MemberList> list = new List<MemberList>();
            DataTable dt = new DataTable();
            string sql = "select CscMain_ID, (CscMain_ID+' '+Fname+' '+Lname) as Name ,CarId,CarModel,Terncode,TernSubCode from PkCard";
            sql += " where Terncode = '" + Terncode + "' and TernSubCode = '" + TernSubCode + "' and CardType = 'M' order by Name desc";
            dt = this.db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new MemberList
                    {
                        csc_main = c["CscMain_ID"].ToString(),
                        name = c["Name"].ToString()
                    }).ToList();
            return list;
        }

        public List<MemberModel> memberlist(int cardtype, string terncode, string ternsubCode)
        {
            SqlParameterCollection parameter = new SqlCommand().Parameters;
            DataTable dt = new DataTable();
            List<MemberModel> list_member = new List<MemberModel>();
            parameter.Add("@Cartype", SqlDbType.Int).Value = cardtype;
            parameter.Add("@terncode", SqlDbType.NVarChar).Value = terncode;
            parameter.Add("@ternSupcode", SqlDbType.NVarChar).Value = ternsubCode;
            dt = db.StoreQuery("rptReportMemberWebStamp", parameter);
            list_member = (from c in dt.AsEnumerable() select new MemberModel {
                 BADGENUMBER = c["BADGENUMBER"].ToString(),
                  Carbill = c["Carbill"].ToString(),
                  Cartype = c["Cartype"].ToString(),
                  Expdate = c["Expdate"].ToString(),
                  Firstdate = c["Firstdate"].ToString(),
                  Model = c["Model"].ToString(),
                  Model1 = c["Model1"].ToString(),
                  Model2 = c["Model2"].ToString(),
                  name1 = c["name1"].ToString(),
                  vehicalID = c["vehicalID"].ToString(),
                 vehicalID1 = c["vehicalID1"].ToString(),
                  vehicalID2 = c["vehicalID2"].ToString()
            }).ToList();
           
            return list_member;
        }

        public List<Member_List> member_list(string terncod, string card_type)
        {
            DataTable dt = new DataTable();
            List<Member_List> list = new List<Member_List>();
            string sql = "";
            if (card_type == "C")
            {
                sql = "select USERID,TFirstname,TLastname from USERINFO t1  where t1.TernCode = '" + terncod + "' and usertype=1 and ParkingMembercar = 1";
            }
            else
            {
                sql = "select USERID,TFirstname,TLastname from USERINFO t1  where t1.TernCode = '" + terncod + "' and usertype=1 and ParkingMembermotor = 1";
            }
            dt = this.db.QueryDataTable(sql);
            list = (from c in dt.AsEnumerable()
                    select new Member_List
                    {
                        MemberID = c["USERID"].ToString(),
                        MemberName = c["USERID"].ToString() + " " + c["TFirstname"].ToString() + " " + c["TLastname"].ToString()
                    }).ToList();

            return list;
        }

        public string RequestCheangMember(string No1, string terncod, string Statustyp, string Custno, string Fname, string Lname, string MemberType, bool Changecontacttype, string Contacttype_New, string Contacttype_Old, string Paytype, bool Changecarid, string CarID_New, string CarModel_New, string Carcolor_New, string CarID1_New, string CarModel1_New, string Carcolor1_New, string CarID2_New, string CarModel2_New, string Carcolor2_New, string CarID_Old, string CarModel_Old, string Carcolor_Old, string CarID2_Old, string CarModel2_Old, string Carcolor2_Old, string CarID3_Old, string CarModel3_Old, string Carcolor3_Old, string Dateactive, string Updateby, string New_Name, string New_lastName, bool Changename)
        {

            try
            {
                SqlParameterCollection parameter = new SqlCommand().Parameters;
                parameter.Add("@No1", SqlDbType.NVarChar).Value = No1;
                parameter.Add("@terncode", SqlDbType.NVarChar).Value = terncod;
                parameter.Add("@Statustype", SqlDbType.NVarChar).Value = Statustyp;
                parameter.Add("@Custno", SqlDbType.NVarChar).Value = Custno;
                parameter.Add("@Fname", SqlDbType.NVarChar).Value = Fname;
                parameter.Add("@Lname", SqlDbType.NVarChar).Value = Lname;
                parameter.Add("@MemberType", SqlDbType.NVarChar).Value = MemberType;
                parameter.Add("@Changecontacttype", SqlDbType.NVarChar).Value = Changecontacttype;
                parameter.Add("@Contacttype_New", SqlDbType.NVarChar).Value = Contacttype_New;
                parameter.Add("@Contacttype_Old", SqlDbType.NVarChar).Value = Contacttype_Old;
                parameter.Add("@Paytype", SqlDbType.NVarChar).Value = Paytype;
                parameter.Add("@Changecarid", SqlDbType.NVarChar).Value = Changecarid;
                parameter.Add("@CarID_New", SqlDbType.NVarChar).Value = CarID_New;
                parameter.Add("@CarModel_New", SqlDbType.NVarChar).Value = CarModel_New;
                parameter.Add("@Carcolor_New", SqlDbType.NVarChar).Value = Carcolor_New;
                parameter.Add("@CarID1_New", SqlDbType.NVarChar).Value = CarID1_New;
                parameter.Add("@CarModel1_New", SqlDbType.NVarChar).Value = CarModel1_New;
                parameter.Add("@Carcolor1_New", SqlDbType.NVarChar).Value = Carcolor1_New;
                parameter.Add("@CarID2_New", SqlDbType.NVarChar).Value = CarID2_New;
                parameter.Add("@CarModel2_New", SqlDbType.NVarChar).Value = CarModel2_New;
                parameter.Add("@Carcolor2_New", SqlDbType.NVarChar).Value = Carcolor2_New;
                parameter.Add("@CarID_Old", SqlDbType.NVarChar).Value = CarID_Old;
                parameter.Add("@CarModel_Old", SqlDbType.NVarChar).Value = CarModel_Old;
                parameter.Add("@Carcolor_Old", SqlDbType.NVarChar).Value = Carcolor_Old;
                parameter.Add("@CarID2_Old", SqlDbType.NVarChar).Value = CarID2_Old;
                parameter.Add("@CarModel2_Old", SqlDbType.NVarChar).Value = CarModel2_Old;
                parameter.Add("@Carcolor2_Old", SqlDbType.NVarChar).Value = Carcolor2_Old;
                parameter.Add("@CarID3_Old", SqlDbType.NVarChar).Value = CarID3_Old;
                parameter.Add("@CarModel3_Old", SqlDbType.NVarChar).Value = CarModel3_Old;
                parameter.Add("@Carcolor3_Old",SqlDbType.NVarChar).Value = Carcolor3_Old;
                parameter.Add("@Dateactive", SqlDbType.DateTime).Value = Convert.ToDateTime(Dateactive);
                parameter.Add("@Updateby", SqlDbType.NVarChar).Value = Updateby;
                parameter.Add("@New_Name", SqlDbType.NVarChar).Value = New_Name;
                parameter.Add("@New_lastName", SqlDbType.NVarChar).Value = New_lastName;
                parameter.Add("@Changename", SqlDbType.NVarChar).Value = Changename;
                db.QueryExecuteNonQueryStor("require_chaeng_member", parameter);

                return "ok";
                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            throw new NotImplementedException();
        }

        public string SendEmailUploadFile(string reqNo1)
        {
            try
            {
                DataTable data_mail_list = new DataTable();
                string sql_mail_list = " SELECT Smtpid, EmailAddress,SMTPServer,SSL,smtppassword,Portdefault from  Pkemaillessor where Isactive = 1 ";
                data_mail_list = this.db.QueryDataTable(sql_mail_list);
                var email_list = (from c in data_mail_list.AsEnumerable() select new {
                    Smtpid = c["Smtpid"].ToString(),
                    EmailAddress = c["EmailAddress"].ToString(),
                    SMTPServer = c["SMTPServer"].ToString(),
                    SSL = Convert.ToInt32( c["SSL"]),
                    smtppassword = c["smtppassword"].ToString(),
                    Portdefault = c["Portdefault"].ToString()
                }).ToList();
                foreach (var _item_email in email_list)
                {
                    List<DocList> doc_list = new List<DocList>();
                    DataTable dt = new DataTable();
                    string sql = " SELECT [No1] ";
                    sql += " ,[Documentype] ";
                    sql += " ,[Documentimage] ";
                    sql += " ,[pathFile] ";
                    sql += " ,[Last_Upd] ";
                    sql += " ,[Updateby] ";
                    sql += " ,[filename] ";
                    sql += " FROM[dbo].[Pkrequirechangememberdoc] ";
                    sql += "  where No1 = '" + reqNo1 + "' ";

                    dt = this.db.QueryDataTable(sql);
                    doc_list = (from c in dt.AsEnumerable()
                                select new DocList
                                {
                                    docType = c["Documentype"].ToString(),
                                    DocName = c["filename"].ToString(),
                                    PathFile = c["pathFile"].ToString()

                                }).ToList();

                    DataTable data_mail = new DataTable();
                    SqlParameterCollection parameterMail = new SqlCommand().Parameters;
                    parameterMail.Add("@p_No1", SqlDbType.VarChar).Value = reqNo1;
                    

                    data_mail = db.StoreQuery("GetMessageMail", parameterMail);

                    var getMesessMail = (from c in data_mail.AsEnumerable() select new { subject = c["SubjectMail"].ToString(), mes = c["MesMail"].ToString() }).SingleOrDefault(); 
                        ///this._dbWarp.GetMessageMail(reqNo1).Select(c => new { subject = c.SubjectMail, mes = c.MesMail }).SingleOrDefault();

                    string from = _item_email.Smtpid;
                    using (MailMessage mail = new MailMessage(from, _item_email.EmailAddress))
                    {

                        mail.Subject = getMesessMail.subject;
                        mail.Body = getMesessMail.mes;
                        foreach (var dataFile in doc_list)
                        {

                            System.Net.Mail.Attachment attachment;
                            attachment = new System.Net.Mail.Attachment(dataFile.PathFile);
                            mail.Attachments.Add(attachment);
                        }

                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = _item_email.SMTPServer;
                        smtp.EnableSsl = _item_email.SSL == 1 ? true : false;
                        NetworkCredential networkCredential = new NetworkCredential(from, _item_email.smtppassword);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = Convert.ToInt32(_item_email.Portdefault);
                        smtp.Send(mail);

                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UserinfoModel userinfo(string userId, string TernCode, string TypeCard)
        {
            DataTable dt = new DataTable();
            UserinfoModel userinfo = new UserinfoModel();
            string sql = "";
            if (TypeCard.Equals("C"))
            {
                sql = " select " +
                  "  userinfo.BADGENUMBER," +
                  "  coalesce(userinfo.tfirstname,'') as name1, " +
                  "  coalesce(userinfo.tlastname,'') as LastName1, " +
                  "  case USERINFO.Member_Carbill when 1 then 'บริษัทร' when 2 then 'พนักงาน' else 'ไม่พบประเภทการเรียกเก็บเงิน' end as Carbill, " +
                  "  case USERINFO.Cardcontact_Cartype when 0 then 'Temp' when 1 then 'Fix' when 2 then 'Cir' when 3 then ' Fix pay more' when 4 then 'Cir up Fix'  end as Cartype, " +
                  "  convert(nvarchar(10), USERINFO.Firstdate_Car,120) as Firstdate, " +
                  "  convert(nvarchar(10), USERINFO.Expdate_Car,120) as Expdate ,  " +
                  "  USERINFO.CarID as vehicalID, " +
                  "  USERINFO.CarModel as Model, " +
                  "  USERINFO.Carcolor as color," +
                  "  USERINFO.CarID1 as vehicalID1," +
                  "  USERINFO.CarModel1 as Model1, " +
                  "  USERINFO.Carcolor1 as color1," +
                  "  USERINFO.CarID2 as vehicalID2," +
                  "  USERINFO.CarModel2 as Model2, " +
                  "  USERINFO.Carcolor2 as color2 " +
                  " from userinfo left join pkdepartments on userinfo.terncode=pkdepartments.terncode " +
                  " left join vcountcardpermember_car on userinfo.badgenumber=vcountcardpermember_car.custno " +
                  " left join pkcar_contact on userinfo.Cardcontact_Car=pkcar_contact.id1 " +
                  " left join pklocation on userinfo.IssueLoc_ID_Car=pklocation.loc_id " +
                  " left join Pklocationparkingzone on userinfo.issueloc_id_car2=Pklocationparkingzone.zoneid1 " +
                  " left join pkgroupbill on userinfo.Groupmemberparking_car=pkgroupbill.groupmember " +
                  " where (usertype=1) and (ParkingMembercar=1) and USERID = '" + userId + "' and userinfo.TernCode = '" + TernCode + "' ";
            }
            else
            {
                sql = "select  " +
                    "  userinfo.BADGENUMBER, " +
                    "  coalesce(userinfo.tfirstname,'') as name1, " +
                    "  coalesce(userinfo.tlastname,'') as LastName1, " +
                    "  case USERINFO.Member_motorbill when 1 then 'บริษัทร' when 2 then 'พนักงาน' else 'ไม่พบประเภทการเรียกเก็บเงิน' end as Carbill, " +
                    "  case USERINFO.Cardcontact_motortype when 0 then 'Temp' when 1 then 'Fix' when 2 then 'Cir' when 3 then ' Fix pay more' when 4 then 'Cir up Fix'  end as Cartype, " +
                    "  convert(nvarchar(10), USERINFO.Firstdate_Motor,120)  as Firstdate, " +
                    "  convert(nvarchar(10),USERINFO.Expdate_Motor,120) as Expdate, " +
                    "  USERINFO.MotorID as vehicalID, " +
                    "  USERINFO.MotorModel as Model, " +
                    "  USERINFO.MotorColor as color, " +
                    "  USERINFO.MotorID1 as vehicalID1, " +
                    "  USERINFO.MotorModel1 as Model1, " +
                    "  USERINFO.MotorColor1  as color1, " +
                    "  USERINFO.MotorID2 as vehicalID2, " +
                    "  USERINFO.MotorModel2 as Model2, " +
                    "  USERINFO.MotorColor2 as color2 " +
                    "	from userinfo left join pkdepartments on userinfo.terncode=pkdepartments.terncode " +
                    " left join vcountcardpermember_motor on userinfo.badgenumber=vcountcardpermember_motor.custno " +
                    " left join pkcar_contact on userinfo.Cardcontact_motor=pkcar_contact.id1 " +
                    " left join pklocation on userinfo.IssueLoc_ID_motor=pklocation.loc_id " +
                    "  left join Pklocationparkingzone on userinfo.issueloc_id_motor2=Pklocationparkingzone.zoneid1 " +
                    " left join pkgroupbill on userinfo.Groupmemberparking_motor=pkgroupbill.groupmember " +
                    "  where (usertype=1) and (ParkingMembermotor=1) and " +
                    "   USERID = '" + userId + "' and userinfo.TernCode = '" + TernCode + "' ";
            }

            dt = this.db.QueryDataTable(sql);
            userinfo = (from c in dt.AsEnumerable()
                        select new UserinfoModel
                        {
                            BADGENUMBER = c["BADGENUMBER"].ToString(),
                            name1 = c["name1"].ToString(),
                            LastName1 = c["LastName1"].ToString(),
                            Carbill = c["Carbill"].ToString(),
                            Cartype = c["Cartype"].ToString(),
                            Firstdate = c["Firstdate"].ToString(),
                            Expdate = c["Expdate"].ToString(),
                            vehicalID = c["vehicalID"].ToString(),
                            Model = c["Model"].ToString(),
                            color = c["color"].ToString(),
                            vehicalID1 = c["vehicalID1"].ToString(),
                            Model1 = c["Model1"].ToString(),
                            color1 = c["color1"].ToString(),
                            vehicalID2 = c["vehicalID2"].ToString(),
                            Model2 = c["Model2"].ToString(),
                            color2 = c["color2"].ToString()

                        }).SingleOrDefault();

            return userinfo;
        }
    }
}