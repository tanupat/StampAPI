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
    
    public partial class PkFareMedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PkFareMedia()
        {
            this.PkFaremedia_Cardtype = new HashSet<PkFaremedia_Cardtype>();
        }
    
        public int Faremedia_ID { get; set; }
        public int Loc_Id { get; set; }
        public string Zdesc { get; set; }
        public Nullable<decimal> LostCard_Fine { get; set; }
        public Nullable<decimal> LostCard_motor_Fine { get; set; }
        public Nullable<decimal> NotEnoughCredit_Fine { get; set; }
        public Nullable<decimal> WrongInOut_Fine { get; set; }
        public Nullable<decimal> Earnest { get; set; }
        public Nullable<decimal> LostSlip_Fine { get; set; }
        public Nullable<short> OverDay_Hr { get; set; }
        public Nullable<short> Minute2Hour { get; set; }
        public Nullable<short> FreeMinuteMotor { get; set; }
        public Nullable<short> FreeMinute { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> Person_ID { get; set; }
        public Nullable<System.DateTime> StartUse { get; set; }
        public Nullable<System.DateTime> StopUse { get; set; }
        public Nullable<decimal> Issuecard_fee { get; set; }
        public Nullable<decimal> Feeperday { get; set; }
        public Nullable<short> Hourpackageperday { get; set; }
        public Nullable<System.DateTime> syndate { get; set; }
        public Nullable<int> sf { get; set; }
        public Nullable<short> DeductFreeMinute { get; set; }
        public Nullable<int> Typecalculate { get; set; }
        public Nullable<decimal> carpermitovernight { get; set; }
        public Nullable<decimal> motorpermitovernight { get; set; }
        public Nullable<short> FreeMinuteMotorMember { get; set; }
        public Nullable<short> FreeMinuteMember { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PkFaremedia_Cardtype> PkFaremedia_Cardtype { get; set; }
    }
}
