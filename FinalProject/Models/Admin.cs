using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Admin
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public DateTime DateOfEngaged { set; get; }
        public DateTime DOB { set; get; }
        [Required]
        public  Double Salary { set; get; }
        public string Gender { set; get; }



    }
}