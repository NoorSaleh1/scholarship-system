using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using FinalProject.Models;
using System.IO;

namespace FinalProject.Controllers
{
    public class ScholarshipController : Controller
    {
        ScDBContext db = new ScDBContext();
        public static int scId;
        public PartialViewResult PartialScholarship()
        {
           

            return PartialView();
        }

        public ActionResult ScholarshipPage()
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

            return View(db.scholarships.ToList());
        }
        [HttpGet]
        public ActionResult IndividualPage(int id=1)
        {
            scId = id;
            var Details = db.scholarships.Where(x => x.ID == id).FirstOrDefault();

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

            return View(Details);
        }
        [HttpPost]
        public ActionResult IndividualPage(Applicant app, HttpPostedFileBase Percentage, HttpPostedFileBase Recommendation)
        {
            if (ModelState.IsValid)
            {
                var map =Server.MapPath("~/assets/img");
                Percentage.SaveAs(Path.Combine(map, Percentage.FileName));
                Recommendation.SaveAs(Path.Combine(map,Recommendation.FileName));
                app.Percentage = Path.Combine(map, Percentage.FileName);
                app.Recommendation = Path.Combine(map, Recommendation.FileName);
                db.Applicants.Add(app);
                db.SaveChanges();
                Join_Scholarship_Applicant x = new Join_Scholarship_Applicant();
                x.ScholarshipID = scId;
                x.AppID = app.ID;
                db.Join_Scholarship_Applicants.Add(x);
                db.SaveChanges();

                ViewBag.Message = "Your Info had been sent successfuly";
            }
            else
            {
                ViewBag.Message = "";
            }

            var Details = db.scholarships.Where(x => x.ID == scId).FirstOrDefault();

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
            return View(Details);
        }
        public ActionResult ScholarshipsManage()
        {
            var Scholar = db.scholarships.ToList();
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIns/Login";
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
                ViewBag.Link = "/LogIns/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }
            return View(Scholar);
        }
        //uadd
        [HttpGet]
        public ActionResult AddScholarship()
        {
            if (ID.StudentValue == 0)
            {
                ViewBag.Link = "/LogIns/Login";
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
                ViewBag.Link = "/LogIns/StudentPage/" + ID.StudentValue;
                ViewBag.Name = db.Students.Single(d => d.ID == ID.StudentValue).FullName;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddScholarship(scholarship sc)
        {
            if (ModelState.IsValid)
            {
                db.scholarships.Add(sc);
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
            return RedirectToAction("ScholarshipsManage");
        }
        //Update
        public static int sId;
        [HttpGet]
        public ActionResult UpdateScholarship(int id)
        {
            sId = id;
            var upd = db.scholarships.Single(d => d.ID == id);

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
            return View(upd);
        }
        [HttpPost]
      
        public ActionResult UpdateScholarship(scholarship sc)
        {
            var upd = db.scholarships.Single(d => d.ID == sId);
            upd.Name = sc.Name;
            //upd.
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
            return RedirectToAction("ScholarshipsManage");
        }
        //delete
        public ActionResult DeleteScholarship(int id)
        {
            var del = db.scholarships.Single(d => d.ID == id);
            db.scholarships.Remove(del);
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
            return RedirectToAction("ScholarshipsManage");
        }


    }
}