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
    public class LibrarianController : Controller
    {
        // GET: Librarian
        public ActionResult Index()
        {
            return View();
        }
        //start

        LibrarianModel Librarian = new LibrarianModel();
        Librarian_Manager obj = new Librarian_Manager();

        [HttpGet]
        public ActionResult AddLibrarian()
        {
            obj.getnextid(Librarian);
            return View(Librarian);
        }

        [HttpPost]
        public ActionResult AddLibrarian(LibrarianModel Librarian, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (ImageFile != null)
                {
                    ImageSaver(Librarian, ImageFile);
                    bool chk = obj.AddLibrarian(Librarian);

                    if (chk)
                    {
                        TempData["Message"] = "Librarian Added!";
                        return RedirectToAction("ViewLibrarian");
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

        public ActionResult ViewLibrarian()
        {

            List<LibrarianModel> Librarian = obj.ViewLibrarian();
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["error"];
            return View(Librarian);
        }


        [HttpGet]
        public ActionResult UpdateLibrarian(int FID)
        {
            LibrarianModel Librarian = obj.GetOneLibrarian(FID);
            TempData["picture"] = Librarian.ImagePath;
            return View(Librarian);
        }
        [HttpPost]
        public ActionResult UpdateLibrarian(LibrarianModel Librarian, HttpPostedFileBase ImageFile)
        {
            Librarian.ImagePath = TempData["picture"].ToString();

            if (ImageFile != null)
            {
                ImageSaver(Librarian, ImageFile);
                bool check = obj.UpdateLibrarian(Librarian);
                if (check)
                {
                    TempData["Message"] = "Librarian Updated!";
                    return RedirectToAction("ViewLibrarian");
                }
                else
                {
                    TempData["error"] = "Librarian can't be Updated!";
                    return RedirectToAction("ViewLibrarian");
                }

            }
            else if (Librarian.ImagePath != null)
            {

                bool check = obj.UpdateLibrarian(Librarian);
                if (check)
                {
                    TempData["Message"] = "Librarian Updated!";
                    return RedirectToAction("ViewLibrarian");
                }
                else
                {
                    TempData["error"] = "Librarian can't be Updated!";
                    return RedirectToAction("ViewLibrarian");
                }

            }
            else
            {
                ViewBag.ImageError = "Plz Upload Image";
                return View();
            }


        }

        public ActionResult DeleteLibrarian(int FID)
        {
            bool check = obj.DeleteLibrarian(FID);
            if (check)
            {
                TempData["Message"] = "Librarian Deleted!";
                return RedirectToAction("ViewLibrarian");
            }
            else
            {
                TempData["error"] = "Librarian can't be Deleted!";
                return RedirectToAction("ViewLibrarian");
            }


        }

        public LibrarianModel ImageSaver(LibrarianModel Librarian, HttpPostedFileBase ImageFile)
        {
            string Filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string Extension = Path.GetExtension(ImageFile.FileName);
            Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
            Librarian.ImagePath = "~/ProjectData/" + Filename;

            Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
            ImageFile.SaveAs(Filename);
            return Librarian;
        }







        //end
    }
}