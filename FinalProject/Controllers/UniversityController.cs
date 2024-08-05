using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class UniversityController : Controller
    {
        // GET: College
        ScDBContext db = new ScDBContext();

        public PartialViewResult PartialUniversities()
        {
            return  PartialView(); 
        }

        public ActionResult UniversitiesPage()
        {
            ScDBContext db = new ScDBContext();

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

            return View(db.Universities.ToList());
        }
        public ActionResult UniversityPage(int id=1)
        {
            var bage = db.Universities.Where(x => x.ID == id).FirstOrDefault();

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

            return View(bage);
        }
        public ActionResult UniversitiesManage()
        {

            var uni = db.Universities.ToList();

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
            return View(uni);
        }
        [HttpGet]
        public ActionResult AddUniversity()
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
        public ActionResult AddUniversity(University sc, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                var map = Server.MapPath("~/assets/img");
                Image.SaveAs(Path.Combine(map, Image.FileName));
                sc.Image = Path.Combine(map, Image.FileName);
                db.Universities.Add(sc);
                db.SaveChanges();

            }

            return RedirectToAction("UniversitiesManage");
        }
        //Update
        public static int curID;
        [HttpGet]
        public ActionResult UpdateUniversity(int id)
        {
            curID = id;
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
            var upd = db.Universities.Single(d => d.ID == id);
                return View(upd);
           
           
        }
        [HttpPost]

        public ActionResult UpdateUniversity(University sc)
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
                var upd = db.Universities.Single(d => d.ID == curID);
                upd.Name = sc.Name;
                upd.Image = sc.Image;
                upd.LanguageRequired = sc.LanguageRequired;
                upd.Location = sc.Location;
                upd.WebLink = sc.WebLink;
                upd.DateOfCreate = sc.DateOfCreate;
                upd.AdditionalInfo = sc.AdditionalInfo;

                db.SaveChanges();

                return RedirectToAction("UniversitiesManage");
            }
            else
            {
                return View(sc);
            }
        }
        //delete
        public ActionResult DeleteUniversity(int id)
        {
            var del = db.Universities.Single(d => d.ID == id);
            db.Universities.Remove(del);
            db.SaveChanges();
            return RedirectToAction("UniversitiesManage");
        }

    }
}