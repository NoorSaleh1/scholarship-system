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
    using System.ComponentModel.DataAnnotations;

    public partial class Applicant
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Student_Info()
        //{
        //    this.Join_Scholarship_Student = new HashSet<Join_Scholarship_Student>();
        //}
    
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public System.DateTime DateOfGraduate { get; set; }
        [Required]
        public string Percentage { get; set; }
        [Required]
        //public int ScholarshipID { get; set; }
        public string Recommendation { get; set; }
        public string State { get; set; }
        

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Join_Scholarship_Student> Join_Scholarship_Student { get; set; }
    }
}
