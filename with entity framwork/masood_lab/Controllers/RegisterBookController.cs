using masood_lab.DBmanager;
using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace masood_lab.Controllers
{
    //[masood_lab.Filters.AuthorizedUser]
    public class RegisterBookController : Controller
    {
        // GET: RegisterBook

        Registration_Manager obj = new Registration_Manager();
        RegistrationModel model = new RegistrationModel();

        public RegisterBookController()
        {
            ViewBag.bookscategory = bookscateory();
            ViewBag.memberscategory = memberscategory();
        }
      
        [HttpGet]
        public ActionResult Register()
        {
            obj.getid(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {    
            if (ModelState.IsValid )
            {
                obj.RegisterBook(model);
                if (model !=null)
                {
                    TempData["Message"] = "Book Registered!";
                    return RedirectToAction("ViewRegister");
                }
            }
            else
            {
                TempData["Message"] = "Invalid Data!";
                return View();
            }
            return View();
        }
        public ActionResult ViewRegister()
        {
           List<RegistrationModel> register= obj.viewregistration();
            ViewBag.Message = TempData["Message"];
            return View(register);
        }
        [HttpGet]
        public ActionResult Update(int fid)
        {
           RegistrationModel regiter= obj.getonedata(fid);
           return View(regiter);
        }
        [HttpPost]
        public ActionResult Update(RegistrationModel model)
        {
            bool chk = obj.update(model);
            if (chk)
            {
                TempData["Message"] = "Data updated!";
                return RedirectToAction("ViewRegister");
            }
            else
            {
                TempData["Message"] = "Data not updated!";
                return RedirectToAction("ViewRegister");
            }
            
        }

        public ActionResult Delete(int fid)
        {
            bool chk = obj.delete(fid);
            if (chk)
            {
                TempData["Message"] = "Data deleted!";
                return RedirectToAction("ViewRegister");
            }
            else
            {
                TempData["Message"] = "Data not deleted!";
                return RedirectToAction("ViewRegister");
            }
        }


        public static IList<SelectListItem> bookscateory()
        {
            Library_systemEntities1 lib = new Library_systemEntities1();
            IList<SelectListItem> book = (from q in lib.tblNewBooks_registration
                                          select new SelectListItem
                                          {
                                              Text = q.BookName,
                                              Value = q.BookID.ToString(),
                                              Selected = false
                                          }).ToList();
            return book;
        }

        public static IList<SelectListItem> memberscategory()
        {
            Library_systemEntities1 lib = new Library_systemEntities1();
            IList<SelectListItem> data = (from q in lib.tblNewMembers_registration
                                          select new SelectListItem
                                          {
                                              Text = q.memberID.ToString(),
                                              Value = q.memberID.ToString(),
                                              Selected = false,
                                          }).ToList();
            return data;
        }
    }
}
