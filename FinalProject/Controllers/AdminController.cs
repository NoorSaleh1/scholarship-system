using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        ScDBContext db = new ScDBContext();

        // GET: Admin
        //[Authorize(Roles = "Admin")]
        public ActionResult ManageAdmin()
        {
            var adm = db.Admins.ToList();

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


            return View(adm);
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddAdmin()
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
        //[Authorize(Roles = "Admin")]
        public ActionResult AddAdmin(Admin ad,string Email)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(ad);
                db.SaveChanges();

                AdminsLogin log = new AdminsLogin();
                log.Email = Email;
                Random x = new Random();
                log.Password = x.Next(1, 9).ToString() + x.Next(1, 9).ToString() + x.Next(1, 9).ToString() + x.Next(1, 9).ToString() + x.Next(1, 9).ToString();
                log.AdminID = db.Admins.Max(b => b.ID);
                db.AdminsLogins.Add(log);

                db.SaveChanges();
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

            return Redirect("/Admin/ManageAdmin");
        }


        public static int curId;
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateAdmin(int id)
        {
            curId = id;
            ViewBag.email = db.AdminsLogins.Single(d => d.AdminID == id).Email;
            ViewBag.Password = db.AdminsLogins.Single(d => d.AdminID == id).Password;
            var up = db.Admins.Single(x => x.ID == id);

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

            return View(up);
        }
            
          [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult UpdateAdmin(Admin ad,string Email,string Pass)
        {
            if (ModelState.IsValid)
            {
                var em = db.AdminsLogins.Single(d => d.AdminID == curId);
                em.Email = Email;
                em.Password=Pass;
                db.SaveChanges();

                var up = db.Admins.Single(x=>x.ID==curId);
                up.Name= ad.Name;
                up.DateOfEngaged = ad.DateOfEngaged;
                db.SaveChanges();
                return Redirect("/Admin/ManageAdmin");
               

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


            return View(ad);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult DeleteAdmin(int id)
        {
            db.AdminsLogins.Remove(db.AdminsLogins.Single(d => d.AdminID == id));
            db.SaveChanges();
            var del = db.Admins.Single(d => d.ID == id);
            db.Admins.Remove(del);
            db.SaveChanges();

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

            return RedirectToAction("ManageAdmin");
        }




    }
}