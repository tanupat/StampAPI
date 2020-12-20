using Parking.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.interfaces
{
    interface IMember
    {
        List<CardType> CarTypeList();

        List<MemberModel> memberlist(int cardtype, string terncode, string ternsubCode);

        List<MemberList> MemberDepartment(string Terncode, string TernSubCode);

        List<DepartmentList> departmentList(string Terncode, string TernSubCode);

        List<CardTypeList> cardTypeList();

        List<memberTranList> getMemberTranList(string terncode, string department, string card_type, string csc_main, string startdate, string enddate, string in_out);

        List<TranRequireMember> getTranRequireMember(string ternCode);

        List<RequireCarTypeList> getCarTypeList();

        List<Requirepayment> getPaymentList();

        List<RequireContacttype> getContacttypeList();

        List<Member_List> member_list(string terncod, string card_type);
        string createNo1(string ternCode);

        string insert_RequestMember(
            string No1,
            string terncode,
            int? Statustype,
            string Fname,
            string Lname,
            string MemberType,
            int? Contacttype_New,
            int? Paytype,
            string CarID_New,
            string CarModel_New,
            string Carcolor_New,
            string CarID1_New,
            string CarModel1_New,
            string Carcolor1_New,
            string CarID2_New,
            string CarModel2_New,
            string Carcolor2_New,
            DateTime? Dateactive,
            string Updateby,
            string Telephone
            );
        List<DocTypeList> getDocList();
        List<DocList> getDataUpload(string reqNo);
        string AddUploadDoc(string No1, string docType, string fileNmae, string image, string updateBy, string PathFile);

        string RequestCheangMember(
           string No1,
            string terncod,
            string Statustyp,
            string Custno,
            string Fname,
            string Lname,
            string MemberType,
            bool Changecontacttype,
            string Contacttype_New,
            string Contacttype_Old,
            string Paytype,
            bool Changecarid,
            string CarID_New,
            string CarModel_New,
            string Carcolor_New,
            string CarID1_New,
            string CarModel1_New,
            string Carcolor1_New,
            string CarID2_New,
            string CarModel2_New,
            string Carcolor2_New,
            string CarID_Old,
            string CarModel_Old,
            string Carcolor_Old,
            string CarID2_Old,
            string CarModel2_Old,
            string Carcolor2_Old,
            string CarID3_Old,
            string CarModel3_Old,
            string Carcolor3_Old,
            string Dateactive,
            string Updateby,
            string New_Name,
            string New_lastName,
            bool Changename
            );
        string CancelMember(
            string No1,
            string terncode,
            int Statustype,
            string Custno,
            string Fname,
            string Lname,
            string MemberType,
            string Dateactive,
            string Updateby,
            string CarID_Old,
            string CarModel_Old,
            string Carcolor_Old,
            string CarID2_Old,
            string CarModel2_Old,
            string Carcolor2_Old,
            string CarID3_Old,
            string CarModel3_Old,
            string Carcolor3_Old
            );
        string SendEmailUploadFile(string reqNo1);
        UserinfoModel userinfo(string userId, string TernCode, string TypeCard);
        List<MemberCardModel> MemberCompany(string ternCode);
        List<DocumentDowloadModel> DowloadDocument();

        DocumentDowloadModel Doc_Dowload(string no1);
    }
}
