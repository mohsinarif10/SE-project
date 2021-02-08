using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using masood_lab.DBmanager;
using System.IO;
namespace masood_lab.Controllers
{
    //[masood_lab.Filters.AuthorizedUser]
    public class MemberController : Controller
    {
       
         //GET: Student
        Member_Manger obj = new Member_Manger();
        MemberModel member = new MemberModel();
        Library_systemEntities1 lib = new Library_systemEntities1();

        [HttpGet]
        public ActionResult AddMember()
        {
           MemberModel members= obj.getnextid();
            return View(members);
        }
    
        [HttpPost]
        public ActionResult AddMember(MemberModel member, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                    if (ImageFile != null)
                    {
                       ImageSaver(member,ImageFile);
                       bool chk = obj.AddMember(member);
                       
                       if (chk)
                       {
                           TempData["Message"] = "Member Registered!";
                           return RedirectToAction("ViewMember");
                       }
                       else
                       {
                           ViewBag.duplication = "Username already exist!";
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

        public ActionResult ViewMember()
        {
            IList<MemberModel> members = obj.Viewmember();
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["error"];
            return View(members);
        }


        [HttpGet]
        public ActionResult UpdateMember(int FID)
        {
            MemberModel member = obj.GetOneMember(FID);
            TempData["imagenull"] = member.ImagePath;
            return View(member);
        }
       [HttpPost]
        public ActionResult UpdateMember(MemberModel member, HttpPostedFileBase ImageFile)
        {
            member.ImagePath = TempData["imagenull"].ToString();
            
                if (ImageFile != null )
                {
                    ImageSaver(member, ImageFile);
                    bool check = obj.UpdateMember(member);
                    if (check)
                    {
                        TempData["Message"] = "Member Updated!";
                        return RedirectToAction("ViewMember");
                    }
                    else
                    {
                        TempData["error"] = "Member can't be Updated!";
                        return RedirectToAction("ViewMember");
                    }

                }

                else if (member.ImagePath != null)
                {
                    bool check = obj.UpdateMember(member);
                    if (check)
                    {
                        TempData["Message"] = "Member Updated!";
                        return RedirectToAction("ViewMember");
                    }
                    else
                    {
                        TempData["error"] = "Member can't be Updated!";
                        return RedirectToAction("ViewMember");
                    }
                }

                else
                {
                    ViewBag.ImageError = "Please Upload Image";
                    return View();
                }

            
      
        }

       public ActionResult DeleteMember(int FID)
       {
           bool check = obj.DeleteMember(FID);
           if (check)
           {
               TempData["Message"] = "Member Deleted!";
               return RedirectToAction("ViewMember");
           }
           else
           {
               TempData["error"] = "Member can't be Deleted!";
               return RedirectToAction("ViewMember");
           }

          
       }

       public MemberModel ImageSaver(MemberModel member, HttpPostedFileBase ImageFile)
       {
           string Filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
           string Extension = Path.GetExtension(ImageFile.FileName);
           Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
           member.ImagePath = "~/ProjectData/" + Filename;

           Filename = Path.Combine(Server.MapPath("~/ProjectData/"), Filename);
           ImageFile.SaveAs(Filename);
           return member;
       }

       
    }
}