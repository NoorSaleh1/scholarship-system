//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string StudyYear { get; set; }
        public string Department { get; set; }
        public string Colleges { get; set; }
        public string University { get; set; }
        public string Due { get; set; }
        public string GradeStatement { get; set; }
        public int  ScholarshipsId { get; set; }
       
        //public virtual Login Login { get; set; }
    }
}
