using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        ScDBContext db = new ScDBContext();

        // GET: Home
        public ActionResult Index()
        {
            //ScDBContext db = new ScDBContext();
            //var Dep = db.Departments.Include(X => X.Colleges);
            ViewBag.University = db.Universities.ToList();
            ViewBag.Scholar = db.scholarships.ToList();
            ViewBag.CountStudent = db.Students.Count();
            ViewBag.CountApplicants = db.Applicants.Count();
            ViewBag.State = ID.AdValue;
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIn/Login";
                if (ID.AdValue == 0)
                {
                    ViewBag.Name ="";
                }
                else
                {
                    ViewBag.Name = db.Admins.Single(d => d.ID == ID.AdValue).Name;

                }

            }
            else
            {
                ViewBag.Link = "/LogIn/StudentPage/"+ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }
            return View();
        }
        public PartialViewResult SuccessRates()
        {
            return PartialView();
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult Contact() {
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
        public ActionResult Contact(Message x)
        {


            if (ModelState.IsValid)
            {
                x.DateOfSend = DateTime.Now;
                db.Messages.Add(x);
                db.SaveChanges();
                 
                ViewBag.Message = "Thank you for your attention ";
            }
            else
            {
                ViewBag.Message = "";
            }
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
        public ActionResult ManageMessages()
        {
            var mes = db.Messages.ToList();
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
            return View(mes);
        }
        //delete
        public ActionResult DeleteMessage(int id)
        {
            var del = db.Messages.Single(d => d.ID == id);
            db.Messages.Remove(del);
            db.SaveChanges();
            return RedirectToAction("ManageMessages");
        }

        //public ststic string[] GetUserRoles(string username)
        //{
        //    using (Role db = new Role())
        //    {
        //        var userRoles = from role in db.Roles
        //                        join userRole in db.Roles on role.Id equals userRole.RoleId
        //                        join user in db.Users on userRole.UserId equals user.Id
        //                        where user.UserName == username
        //                        select role.Name;

        //        return userRoles.ToArray();
        //    }
        //}

    }
}