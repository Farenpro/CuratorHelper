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
    
    public partial class DemoExam
    {
        public int ID { get; set; }
        public int DemoExamNameID { get; set; }
        public byte Mark { get; set; }
        public int StudentID { get; set; }
    
        public virtual DemoExamName DemoExamName { get; set; }
        public virtual Student Student { get; set; }
    }
}