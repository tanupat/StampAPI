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
    
    public partial class Pkfee
    {
        public int Id1 { get; set; }
        public string Receiptno { get; set; }
        public string Typepay { get; set; }
        public Nullable<System.DateTime> Datepay { get; set; }
        public Nullable<decimal> Fee { get; set; }
        public Nullable<decimal> NetFee { get; set; }
        public Nullable<decimal> FeeWithholding { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> Withholding { get; set; }
        public string TernCode { get; set; }
        public string TernSubCode { get; set; }
        public string CustNo { get; set; }
        public string Name { get; set; }
        public string Scr_No { get; set; }
        public string CscMain_ID { get; set; }
        public string Rabbit_ID { get; set; }
        public Nullable<int> CardType_ID { get; set; }
        public string Remark { get; set; }
        public string CardType { get; set; }
        public string Cartype { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> Person_ID { get; set; }
        public Nullable<int> Paytype { get; set; }
    }
}
