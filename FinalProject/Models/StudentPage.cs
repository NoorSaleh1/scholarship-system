using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class StudentPage
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string StudyYear { get; set; }
        public string Department { get; set; }
        public string Colleges { get; set; }
        public string University { get; set; }
        public string Due { get; set; }
        public string GradeStatement { get; set; }
        public string Image { get; set; }
    }
}