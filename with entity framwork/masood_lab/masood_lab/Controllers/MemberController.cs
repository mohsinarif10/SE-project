using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace masood_lab.Controllers
{
    public class MemberController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddMember(MemberModel member) 
        {
            return View();
        }
        public ActionResult SearchMember()
        {
            return View();
        }
        public ActionResult DropMember()
        {
            return View();
        }
        public ActionResult ViewMember()
        {
            List<MemberModel> members = new List<MemberModel>
            {
                new MemberModel{Firstname="Masood",Lastname="Arif",Phonenumber="0323232",
                NIC="423214321334",Address="karachi, pakistan",
                Email="masoodarif1313@gmail.com",Date_of_birth="12/12/2020",
                Password="masood",RepeatPassword="masood",Gender="male",
                Department="COCIS",Csharp=true},

                new MemberModel{Firstname="Masood",Lastname="Arif",Phonenumber="0323232",
                NIC="423214321334",Address="karachi, pakistan",
                Email="masoodarif1313@gmail.com",Date_of_birth="12/12/2020",
                Password="masood",RepeatPassword="masood",Gender="male",
                Department="COCIS",Csharp=true},

                new MemberModel{Firstname="Masood",Lastname="Arif",Phonenumber="0323232",
                NIC="423214321334",Address="karachi, pakistan",
                Email="masoodarif1313@gmail.com",Date_of_birth="12/12/2020",
                Password="masood",RepeatPassword="masood",Gender="male",
                Department="COCIS",Csharp=true}
            };
            return View(members);
        }
        public ActionResult UpdateMember()
        {
            return View();
        }
    }
}