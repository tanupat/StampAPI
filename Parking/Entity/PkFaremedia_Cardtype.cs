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
    
    public partial class PkFaremedia_Cardtype
    {
        public int FareMedia_ID { get; set; }
        public int Loc_ID { get; set; }
        public int CardType_ID { get; set; }
        public string PayMonthFlg { get; set; }
        public string PrintSlipFlg { get; set; }
        public Nullable<int> ValidPeriod { get; set; }
        public Nullable<int> SpecialPeriod { get; set; }
        public string EventAccept { get; set; }
        public string EventCode { get; set; }
        public string EventPrice { get; set; }
        public string HolAccept { get; set; }
        public string HolCode { get; set; }
        public string HolPrice { get; set; }
        public string WeekAccept { get; set; }
        public string WeekCode { get; set; }
        public string WeekPrice { get; set; }
        public string NormalAccept { get; set; }
        public string NormalPrice { get; set; }
        public Nullable<short> ValidWarnDay { get; set; }
        public string UseCount { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public string Person_ID { get; set; }
        public string AddCreditFlag { get; set; }
        public string MinCreditFlag { get; set; }
        public string NegCreditFlag { get; set; }
        public string InitCredit { get; set; }
        public Nullable<int> PurchaseType { get; set; }
        public string OneDayFlag { get; set; }
        public string AlarmFlag { get; set; }
        public string BonusFlag { get; set; }
        public Nullable<int> Bonustype { get; set; }
        public Nullable<System.DateTime> syndate { get; set; }
        public Nullable<int> sf { get; set; }
        public int Overnightfee { get; set; }
        public string EventPriceovernight { get; set; }
        public string HolPriceovernight { get; set; }
        public string Weekpriceovernight { get; set; }
        public string NormalPriceovernight { get; set; }
        public string OnePriceovernight { get; set; }
        public Nullable<decimal> fineparkovernight { get; set; }
        public string EventPricebeforetime { get; set; }
        public string HolPricebeforetime { get; set; }
        public string Weekpricebeforetime { get; set; }
        public string NormalPricebeforetime { get; set; }
        public string OnePricebeforetime { get; set; }
    
        public virtual PkCardType PkCardType { get; set; }
        public virtual PkFareMedia PkFareMedia { get; set; }
    }
}
