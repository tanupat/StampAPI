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
    
    public partial class Pkparkingpermitovernight
    {
        public string No1 { get; set; }
        public Nullable<System.DateTime> Dateissue { get; set; }
        public string Terncode { get; set; }
        public string CustNo { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public string Note { get; set; }
        public string Recipientname { get; set; }
        public Nullable<int> PayType { get; set; }
        public Nullable<int> Month1 { get; set; }
        public Nullable<int> Year1 { get; set; }
        public Nullable<int> Permittype { get; set; }
        public int Cancel { get; set; }
        public string Cartype { get; set; }
        public Nullable<decimal> Fee { get; set; }
    }
}
