using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        ScDBContext db = new ScDBContext();
        // GET: Student
        public ActionResult ApplicantsManage()
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }
           
            return View(db.Applicants.Where(d=>d.State== "UnStated").ToList());
        }
        public ActionResult StudentsManage()
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }

            return View(db.Students.ToList());
        }
        public ActionResult AcceptApplicants(int id)
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }

            var ac = db.Applicants.Single(d => d.ID == id);
            ac.State = "accepted";
            db.SaveChanges();
            var a = db.Join_Scholarship_Applicants.Single(d => d.AppID == id);
            
            Student s = new Student();
            s.FullName = ac.Name;
            s.ScholarshipsId = a.ScholarshipID;
            db.Students.Add(s);
            db.SaveChanges();
            return Redirect("ApplicantsManage");

        }
        public ActionResult RejectApplicants(int id)
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }

            var ac = db.Applicants.Single(d => d.ID == id);
            ac.State = "Unaccepted";
            db.SaveChanges();
            return Redirect("ApplicantsManage");

        }
        public static int UpID;
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            UpID = id;

            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }
            return View(db.Students.Single(d => d.ID == id));
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student st)
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name = "";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }

            return View(db.Students.Single(d => d.ID == UpID));
        }
    }
}