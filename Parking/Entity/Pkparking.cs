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
    
    public partial class Pkparking
    {
        public string ParkingID { get; set; }
        public int Site_Id { get; set; }
        public int Loc_id { get; set; }
        public string Floor_Id { get; set; }
        public string parkingname { get; set; }
        public string Custno { get; set; }
        public string TernCode { get; set; }
        public string Status { get; set; }
        public string Cscmain_id { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> Person_ID { get; set; }
    }
}