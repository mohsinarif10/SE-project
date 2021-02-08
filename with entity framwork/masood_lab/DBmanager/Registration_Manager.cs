using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masood_lab.DBmanager
{
    public class Registration_Manager:General
    {
        public int getid(RegistrationModel model)
        {
            try
            {
                int data = lib.tblBooksMembers.Max(x => x.registrationID) + 1;
                model.registrationID = data;
                return data;
            }
            catch (Exception)
            {

                int data=0;
                return data;
            }
           

        }

        public void RegisterBook(RegistrationModel model)
        {
            tblBooksMember data = new tblBooksMember()
            {
                BookID=model.BooksID,
                MemberID=model.MemberID,
                IssuedDate=model.IssuedDate,
                ExpiryDate=model.ExpiryDate
            };
            lib.tblBooksMembers.Add(data);
            lib.SaveChanges();

        }

        public List<RegistrationModel> viewregistration()
        {
            List<RegistrationModel> registrations = (from q in lib.tblBooksMembers
                                                     select new RegistrationModel
                                                         {
                                                             registrationID = q.registrationID,
                                                             BookName = q.tblNewBooks_registration.BookName,
                                                             MemberName = q.tblNewMembers_registration.FullName,
                                                             IssuedDate = q.IssuedDate,
                                                             ExpiryDate = q.ExpiryDate
                                                         }).ToList();
            return registrations;
            
        }

        public RegistrationModel getonedata(int id)
        {
            var data = (from q in lib.tblBooksMembers
                        where q.registrationID == id
                        select new RegistrationModel
                        {
                            registrationID=q.registrationID,
                            BooksID=q.BookID,
                            MemberID=q.MemberID,
                            IssuedDate=q.IssuedDate,
                            ExpiryDate=q.ExpiryDate
                        }).FirstOrDefault();
            return data;
            
        }

        public bool update(RegistrationModel model)
        {
            var data = lib.tblBooksMembers.Where(x => x.registrationID == model.registrationID).FirstOrDefault();
            data.registrationID = model.registrationID;
            data.BookID = model.BooksID;
            data.MemberID = model.MemberID;
            data.IssuedDate = model.IssuedDate;
            data.ExpiryDate = model.ExpiryDate;
            lib.SaveChanges();
            return true;
        }

        public bool delete(int fid)
        {
            var data = lib.tblBooksMembers.Where(x => x.registrationID == fid).FirstOrDefault();
            lib.tblBooksMembers.Remove(data);
            bool chk = false;
            try
            {
                lib.SaveChanges();
                return chk = true;
            }
            catch (Exception ex)
            {

                return chk = false;
            }
        }


    }
}