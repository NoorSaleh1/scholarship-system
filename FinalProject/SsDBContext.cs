using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FinalProject.Models;

namespace FinalProject
{
    public class ScDBContext:DbContext
    {

        public ScDBContext():base("Server=NOORSALEH\\MSSQLSERVER3;Database=scholarship;Integrated Security=true")
        {
            }

        public  DbSet<College> Colleges { get; set; }
        public  DbSet<Department> Departments { get; set; }
        public  DbSet<Join_Department_Scholarship> Join_Department_Scholarship { get; set; }
                    
        public  DbSet<Join_Scholarship_Applicant> Join_Scholarship_Applicants { get; set; }
        public  DbSet<joinTable> joinTables { get; set; }
       
        public  DbSet<scholarship> scholarships { get; set; }
        public  DbSet<Student> Students{ get; set; }
        public  DbSet<Applicant> Applicants { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminsLogin> AdminsLogins { get; set; }
        public  DbSet<University> Universities { get; set; }
        public  DbSet<Message> Messages{ get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}