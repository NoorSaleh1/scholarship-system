using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Login
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        
        public string Password { get; set; }
        public int StudentID { get; set; }
    }
}