﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class scholarshipEntities5 : DbContext
    {
        public scholarshipEntities5()
            : base("name=scholarshipEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Join_Department_Scholarship> Join_Department_Scholarship { get; set; }
        public virtual DbSet<Join_Scholarship_Student> Join_Scholarship_Student { get; set; }
        public virtual DbSet<joinTable> joinTables { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<scholarship> scholarships { get; set; }
        public virtual DbSet<scholarship_student> scholarship_student { get; set; }
        public virtual DbSet<Student_Info> Student_Info { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tessst> tesssts { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
