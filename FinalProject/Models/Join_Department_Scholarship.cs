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
    
    public partial class Join_Department_Scholarship
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<int> ScholarshipID { get; set; }

        //public virtual Department Department { get; set; }
        //public virtual scholarship scholarship { get; set; }
    }
}
