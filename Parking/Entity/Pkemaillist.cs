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
    
    public partial class Pkemaillist
    {
        public int Tran_Id { get; set; }
        public Nullable<System.DateTime> Date_Email { get; set; }
        public string FromTenant_Id { get; set; }
        public string FromTenant_Name { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Clearemail { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public string Updateby { get; set; }
    }
}
