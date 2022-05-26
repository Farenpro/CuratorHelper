//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuratorHelper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GraduateWork
    {
        public int ID { get; set; }
        public int GraduateWorkTypeID { get; set; }
        public string Name { get; set; }
        public System.DateTime ProtectDate { get; set; }
        public byte Mark { get; set; }
        public int StudentID { get; set; }
        public int QualificationID { get; set; }
    
        public virtual GraduateWorkType GraduateWorkType { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual Student Student { get; set; }
    }
}
