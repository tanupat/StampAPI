//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parking.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERINFO
    {
        public int nIndex { get; set; }
        public string USERID { get; set; }
        public string BADGENUMBER { get; set; }
        public string SSN { get; set; }
        public string userid7b { get; set; }
        public string RefNo { get; set; }
        public string GENDER { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> nTitle { get; set; }
        public Nullable<System.DateTime> BIRTHDAY { get; set; }
        public Nullable<System.DateTime> HIREDDAY { get; set; }
        public string Addr1 { get; set; }
        public string ZIP { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> SECURITYFLAGS { get; set; }
        public byte[] PHOTO { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string TFirstname { get; set; }
        public string TLastname { get; set; }
        public string TernCode { get; set; }
        public string TernSubcode { get; set; }
        public Nullable<int> Positioninfo { get; set; }
        public string Verity_Type { get; set; }
        public string Passwords { get; set; }
        public string ActivePass { get; set; }
        public string IDCard { get; set; }
        public string CardActive { get; set; }
        public Nullable<System.DateTime> CardStartDate { get; set; }
        public Nullable<System.DateTime> CardExpireDate { get; set; }
        public string Passwordweb { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> workmode { get; set; }
        public Nullable<int> group { get; set; }
        public Nullable<int> FPC { get; set; }
        public Nullable<int> NF { get; set; }
        public Nullable<int> MCGourp { get; set; }
        public Nullable<System.DateTime> ExpireCard { get; set; }
        public Nullable<int> WorkStartH { get; set; }
        public Nullable<int> workStartM { get; set; }
        public Nullable<int> WorkEndH { get; set; }
        public Nullable<int> WorkEndM { get; set; }
        public Nullable<int> GroupTime { get; set; }
        public string faceauthority { get; set; }
        public int Facecalid { get; set; }
        public string Faceopenmode { get; set; }
        public string Facecheckmode { get; set; }
        public string Faceidcard { get; set; }
        public Nullable<int> ncardno { get; set; }
        public Nullable<int> Vein_Access { get; set; }
        public string Vein_Timezone { get; set; }
        public Nullable<int> Vein_userspecial { get; set; }
        public Nullable<int> Vein_usertype { get; set; }
        public Nullable<int> Vein_userLevel { get; set; }
        public Nullable<int> Vein_user1toN { get; set; }
        public Nullable<int> Vein_Active { get; set; }
        public Nullable<int> Vein_Blockuser { get; set; }
        public Nullable<int> Vein_BlockDate { get; set; }
        public Nullable<int> Vein_Accessmode { get; set; }
        public string Vein_Schedule { get; set; }
        public Nullable<int> Vein_batchadmin { get; set; }
        public Nullable<int> usertype { get; set; }
        public string Groupdevicetime { get; set; }
        public string CarID { get; set; }
        public string CarModel { get; set; }
        public string Carcolor { get; set; }
        public string CarID1 { get; set; }
        public string CarModel1 { get; set; }
        public string Carcolor1 { get; set; }
        public string CarID2 { get; set; }
        public string CarModel2 { get; set; }
        public string Carcolor2 { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> Person_ID { get; set; }
        public string Imagepaths { get; set; }
        public Nullable<System.DateTime> syndate { get; set; }
        public Nullable<int> nSecurityLevel { get; set; }
        public Nullable<int> sf { get; set; }
        public string customfield1 { get; set; }
        public string customfield2 { get; set; }
        public string customfield3 { get; set; }
        public string customfield4 { get; set; }
        public Nullable<int> MSticker { get; set; }
        public Nullable<int> MReward { get; set; }
        public Nullable<int> StickerGp { get; set; }
        public string Webusername { get; set; }
        public string Webpassword { get; set; }
        public Nullable<int> ParkingMembercar { get; set; }
        public Nullable<int> ParkingMemberMotor { get; set; }
        public string MotorID { get; set; }
        public string MotorModel { get; set; }
        public string MotorColor { get; set; }
        public string MotorID1 { get; set; }
        public string MotorModel1 { get; set; }
        public string MotorColor1 { get; set; }
        public string MotorID2 { get; set; }
        public string MotorModel2 { get; set; }
        public string MotorColor2 { get; set; }
        public string Cardcontact_Car { get; set; }
        public Nullable<int> Cardcontact_Carright { get; set; }
        public Nullable<int> Cardcontact_Cartype { get; set; }
        public Nullable<decimal> Memberfee_car_cash { get; set; }
        public string StatuspayParking_Car { get; set; }
        public Nullable<System.DateTime> DateActive_Car { get; set; }
        public string Pay_car { get; set; }
        public string Occupied_Car { get; set; }
        public string Groupmemberparking_Car { get; set; }
        public string Cardcontact_Motor { get; set; }
        public Nullable<int> Cardcontact_motorright { get; set; }
        public Nullable<int> Cardcontact_motortype { get; set; }
        public Nullable<decimal> Memberfee_motor_cash { get; set; }
        public string StatuspayParking_Motor { get; set; }
        public Nullable<System.DateTime> DateActive_Motor { get; set; }
        public string Pay_Motor { get; set; }
        public string Occupied_Motor { get; set; }
        public string Groupmemberparking_Motor { get; set; }
        public Nullable<int> IssueLoc_ID_Car { get; set; }
        public Nullable<int> IssueLoc_ID_Car2 { get; set; }
        public Nullable<int> IssueLoc_ID_Motor { get; set; }
        public Nullable<int> IssueLoc_ID_Motor2 { get; set; }
        public Nullable<System.DateTime> Firstdate_Car { get; set; }
        public Nullable<System.DateTime> Expdate_Car { get; set; }
        public Nullable<System.DateTime> Firstdate_Motor { get; set; }
        public Nullable<System.DateTime> Expdate_Motor { get; set; }
        public Nullable<int> CompanyCar { get; set; }
        public Nullable<int> CompanyMotor { get; set; }
        public Nullable<decimal> Memberfee_car { get; set; }
        public Nullable<decimal> Memberfee_Motor { get; set; }
        public Nullable<int> Member_Carbill { get; set; }
        public int Member_motorbill { get; set; }
        public string Carparking { get; set; }
        public string Motorparking { get; set; }
        public Nullable<System.DateTime> Lasttopupdate { get; set; }
        public Nullable<int> Lastcreditlimit { get; set; }
        public Nullable<int> Dome { get; set; }
        public Nullable<int> meal { get; set; }
        public string EmailAddress { get; set; }
        public string SlifeID { get; set; }
        public string GroupLiftaccess { get; set; }
        public string ExtendFloor { get; set; }
        public string LimitFloor { get; set; }
        public Nullable<int> status_a { get; set; }
        public string CarID3 { get; set; }
        public string CarModel3 { get; set; }
        public string Carcolor3 { get; set; }
        public string CarID4 { get; set; }
        public string CarModel4 { get; set; }
        public string Carcolor4 { get; set; }
        public string CarID5 { get; set; }
        public string CarModel5 { get; set; }
        public string Carcolor5 { get; set; }
        public string MotorID3 { get; set; }
        public string MotorModel3 { get; set; }
        public string MotorColor3 { get; set; }
        public string MotorID4 { get; set; }
        public string MotorModel4 { get; set; }
        public string MotorColor4 { get; set; }
        public string MotorID5 { get; set; }
        public string MotorModel5 { get; set; }
        public string MotorColor5 { get; set; }
    
        public virtual USERINFO USERINFO1 { get; set; }
        public virtual USERINFO USERINFO2 { get; set; }
    }
}
