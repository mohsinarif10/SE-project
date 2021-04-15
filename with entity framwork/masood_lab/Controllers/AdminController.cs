using masood_lab.DBmanager;
using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masood_lab.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        AdminModel Librarian = new AdminModel();
        Admin_Manager obj = new Admin_Manager();
        public ActionResult Index()
        {//sjudsdasdusad
            return View();
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            obj.getnextid(Librarian);
            return View(Librarian);
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminModel Admin, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (ImageFile != null)
                {
                    ImageSaver(Librarian, ImageFile);
                    Admin.ImagePath = TempData["imgfile"].ToString();
                    bool chk = obj.AddAdmin(Admin);
                    if (chk)
                    {
                        ViewBag.added = "Admin Registered!";
                        return View();
                        //return RedirectToAction("Addmember", "Member");
                    }
                    else
                    {
                        ViewBag.error = "username already registered!";
                        return View();
                    }

                }
                else
                {
                    ViewBag.ImageError = "Plz Upload Image";
                    return View();
                }


            }
            else
            {

                return View();
            }


        }

        public AdminModel ImageSaver(AdminModel admin, HttpPostedFileBase ImageFile)
        {
            string Filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string Extension = Path.GetExtension(ImageFile.FileName);
            Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
            admin.ImagePath = "~/ProjectData/" + Filename;

            Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
            ImageFile.SaveAs(Filename);
            TempData["imgfile"] = admin.ImagePath;
            return admin;
        }

    }
}
