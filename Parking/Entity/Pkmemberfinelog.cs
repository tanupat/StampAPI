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
    
    public partial class Pkmemberfinelog
    {
        public int ID { get; set; }
        public string Inouttran_id { get; set; }
        public string Scr_no { get; set; }
        public Nullable<System.DateTime> Logtimestamp { get; set; }
        public Nullable<int> completeflag { get; set; }
        public Nullable<int> GateID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string carid { get; set; }
        public string CscMain_ID { get; set; }
    }
}