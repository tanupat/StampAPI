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
    
    public partial class SCHCLASS
    {
        public int SCHCLASSID { get; set; }
        public string SCHNAME { get; set; }
        public System.DateTime STARTTIME { get; set; }
        public System.DateTime ENDTIME { get; set; }
        public Nullable<int> LATEMINUTES { get; set; }
        public Nullable<int> EARLYMINUTES { get; set; }
        public Nullable<int> CHECKIN { get; set; }
        public Nullable<int> CHECKOUT { get; set; }
        public Nullable<System.DateTime> CHECKINTIME1 { get; set; }
        public Nullable<System.DateTime> CHECKINTIME2 { get; set; }
        public Nullable<System.DateTime> CHECKOUTTIME1 { get; set; }
        public Nullable<System.DateTime> CHECKOUTTIME2 { get; set; }
        public Nullable<int> COLOR { get; set; }
        public Nullable<int> AUTOBIND { get; set; }
        public Nullable<double> WorkDay { get; set; }
        public string SensorID { get; set; }
        public string Sun1 { get; set; }
        public string Mon1 { get; set; }
        public string Tue1 { get; set; }
        public string Wed1 { get; set; }
        public string Thu1 { get; set; }
        public string Fri1 { get; set; }
        public string Sat1 { get; set; }
        public Nullable<System.DateTime> BreakS { get; set; }
        public Nullable<System.DateTime> BreakE { get; set; }
        public Nullable<bool> CBreak { get; set; }
        public Nullable<bool> OTEnd { get; set; }
        public Nullable<int> OTMin { get; set; }
        public Nullable<int> OTMax { get; set; }
        public Nullable<bool> OTNextDay { get; set; }
        public Nullable<int> OTBreak { get; set; }
        public Nullable<int> OTRound { get; set; }
        public Nullable<int> LateToAbsent { get; set; }
        public Nullable<bool> FILO { get; set; }
        public Nullable<bool> EarlyWork { get; set; }
        public Nullable<int> HolidayTypeSCH { get; set; }
        public Nullable<bool> OTApprove { get; set; }
        public Nullable<int> BreakMin { get; set; }
    }
}
