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
    
    public partial class VCBox
    {
        public int VBoxIndex { get; set; }
        public string BoxID { get; set; }
        public int Idgate { get; set; }
        public string BoxName { get; set; }
        public string VCardID { get; set; }
        public string VCardNos { get; set; }
        public Nullable<System.DateTime> INDAte { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public Nullable<int> Clearing { get; set; }
    }
}