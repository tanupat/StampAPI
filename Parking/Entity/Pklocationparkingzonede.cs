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
    
    public partial class Pklocationparkingzonede
    {
        public int Zoneid1 { get; set; }
        public int Loc_Id { get; set; }
        public Nullable<int> Timein1 { get; set; }
    
        public virtual Pklocationparkingzone Pklocationparkingzone { get; set; }
    }
}