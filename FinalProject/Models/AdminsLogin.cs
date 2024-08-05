using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class AdminsLogin
    {
        public int ID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public int AdminID { set; get; }

    }
}