using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masood_lab.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addbook()
        {
            return View();
        }
        public ActionResult Searchbook()
        {
            return View();
        }
        public ActionResult Dropbook()
        {
            return View();
        }
        public ActionResult Viewbook()
        {
            return View();
        }
        public ActionResult Updatebook()
        {
            return View();
        }
    }
}