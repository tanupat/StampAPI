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
    
    public partial class CHECKEXACT
    {
        public int EXACTID { get; set; }
        public string Userid { get; set; }
        public Nullable<System.DateTime> CHECKTIME { get; set; }
        public string CHECKTYPE { get; set; }
        public Nullable<int> ISADD { get; set; }
        public string YUYIN { get; set; }
        public Nullable<int> ISMODIFY { get; set; }
        public Nullable<int> ISDELETE { get; set; }
        public Nullable<int> INCOUNT { get; set; }
        public Nullable<int> ISCOUNT { get; set; }
        public string MODIFYBY { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public string Badgenumber { get; set; }
        public Nullable<System.DateTime> Dateallow { get; set; }
        public Nullable<System.DateTime> Stime { get; set; }
        public Nullable<System.DateTime> Etime { get; set; }
    }
}