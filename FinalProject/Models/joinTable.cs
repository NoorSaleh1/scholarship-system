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
    
    public partial class joinTable
    {
        public int ID { get; set; }
        public double AcceptanceRate { get; set; }
        public string LanquageRequired { get; set; }
        public Nullable<int> UniversityID { get; set; }
        public Nullable<int> SpecialtyID { get; set; }
    }
}
