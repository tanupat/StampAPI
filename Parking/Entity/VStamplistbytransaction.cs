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
    
    public partial class VStamplistbytransaction
    {
        public string InOutTran_ID { get; set; }
        public Nullable<System.DateTime> Indate { get; set; }
        public Nullable<System.DateTime> Outdate { get; set; }
        public Nullable<int> CompleteFlag { get; set; }
        public string InOutTranstamp_ID { get; set; }
        public string Expr1 { get; set; }
        public string StampCode { get; set; }
        public string Terncode { get; set; }
        public string Ternsubcode { get; set; }
        public Nullable<System.DateTime> datetimestamp { get; set; }
        public Nullable<int> Mintenant { get; set; }
        public Nullable<decimal> FeeTenant { get; set; }
        public Nullable<decimal> Feevisitor { get; set; }
        public Nullable<int> SingleStampFlg { get; set; }
        public Nullable<int> Active1 { get; set; }
        public Nullable<int> adminlevel { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> Person_ID { get; set; }
        public string Adminname { get; set; }
        public Nullable<int> sf { get; set; }
        public Nullable<System.DateTime> syndate { get; set; }
        public string custom { get; set; }
        public string custom_stamp { get; set; }
    }
}
