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
    
    public partial class CCTV
    {
        public Nullable<int> CCTVID { get; set; }
        public string CCTVName { get; set; }
        public int SDID { get; set; }
        public string Field1 { get; set; }
        public int Channel { get; set; }
        public string IPAddress { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> Active { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> PosX { get; set; }
        public Nullable<int> PosY { get; set; }
        public string Access { get; set; }
        public string Time { get; set; }
        public Nullable<System.DateTime> CHECKTIME { get; set; }
        public string CHECKTYPE { get; set; }
        public Nullable<int> VERIFYCODE { get; set; }
        public string SENSORID { get; set; }
        public string ck { get; set; }
        public Nullable<int> resv1 { get; set; }
        public string type1 { get; set; }
        public string MainType { get; set; }
        public string ServerName { get; set; }
        public Nullable<int> ServerPort { get; set; }
        public Nullable<int> INZone { get; set; }
        public Nullable<int> OutZone { get; set; }
        public byte[] PictureON { get; set; }
        public byte[] PictureOFF { get; set; }
        public Nullable<int> PictureIndex { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}