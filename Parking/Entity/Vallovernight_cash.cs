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
    
    public partial class Vallovernight_cash
    {
        public string InOutTran_ID { get; set; }
        public Nullable<System.DateTime> DateOut1 { get; set; }
        public string CscMain_ID { get; set; }
        public Nullable<int> typecard { get; set; }
        public Nullable<decimal> sumtotal { get; set; }
        public Nullable<decimal> overnightpark_fine { get; set; }
        public string cartype { get; set; }
        public Nullable<int> cashpay { get; set; }
        public string terncode { get; set; }
    }
}