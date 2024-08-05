using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class LogInController : Controller
    {
        

        ScDBContext db = new ScDBContext();

     
        

        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public ActionResult Login()
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
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
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

            if (ModelState.IsValid)
            {
                try
                {
                    if (login.Email.Contains("@ad")||login.Email.Contains("@sad"))
                    {
                        
                        var Checklogin = db.AdminsLogins.SingleOrDefault(x => x.Email == login.Email);
                        if (Checklogin != null & (login.Email == Checklogin.Email && login.Password == Checklogin.Password))
                        {

                            ID.AdValue = Checklogin.ID;
                            return Redirect("/Home/index");


                        }
                        else
                        {
                            ViewBag.Message = "Invalid Email Or Password";


                        }
                    }
                   
                    else
                    {
                        var Checklogin = db.Logins.SingleOrDefault(e => e.Email == login.Email&&e.Password==login.Password);
                        if (Checklogin != null )
                        {
                            // ID.LogInValue = Checklogin.ID;
                            ID.StudentValue = Checklogin.StudentID;
                            return Redirect("/LogIn/StudentPage/" + Checklogin.StudentID.ToString());


                        }
                        else
                        {
                            ViewBag.Message = "Invalid Email Or Password";

                        }
                    }

                    //string email = Checklogin.Email;
                    //string pass = Checklogin.Password;


                }
                catch(Exception e)
                {
                    ViewBag.Message = "Invalid Email Or Password";

                }

            }
            return View();
        }
        public static int Id;
        [HttpGet]
        public ActionResult StudentPage(int id = 1)
        {

            var student_page = db.Students.Single(n => n.ID == id);
            ViewBag.Message = "";
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
            return View(student_page);
        }
        [HttpPost]
        public ActionResult StudentPage(HttpPostedFileBase Grades)
        {
            var student_page = db.Students.Single(n => n.ID == Id);
            var map = Server.MapPath("~/assets/img");
            Grades.SaveAs(Path.Combine(map, Grades.FileName));
            student_page.GradeStatement = Path.Combine(map, Grades.FileName);
            db.SaveChanges();
           
            //if (Grades != null)
            //{
            //    ViewBag.Message = "Successful";

            //    student_page.GradeStatement = Grades;
            //    db.SaveChanges();
            //}

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
            return View(student_page);
        }
        public ActionResult LogOut()
        {
            ID.sysId = 0;
            ID.AdValue = 0;
            ID.StudentValue = 0;
            return Redirect("/Home/Index");
        }
    }
}