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
    
    public partial class VSummarystampdetail_motor
    {
        public string InOutTran_ID { get; set; }
        public Nullable<System.DateTime> DateOut1 { get; set; }
        public Nullable<decimal> sumtotal { get; set; }
        public Nullable<decimal> lost_card_fine { get; set; }
        public Nullable<decimal> Overnightpark_Fine { get; set; }
        public string Terncode { get; set; }
        public string Ternsubcode { get; set; }
        public string StampCode { get; set; }
        public Nullable<decimal> FeeTenant { get; set; }
        public Nullable<decimal> Feevisitor { get; set; }
        public string Zdesc { get; set; }
        public string DeptName { get; set; }
    }
}
