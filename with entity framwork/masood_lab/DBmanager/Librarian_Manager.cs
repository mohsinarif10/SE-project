using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masood_lab.DBmanager
{
    public class Librarian_Manager : General
    {
        //start

        public bool AddLibrarian(LibrarianModel Librarian)
        {

            tbl_librarian data = new tbl_librarian()
            {
                lib_id = Librarian.lib_id,
                lib_username = Librarian.lib_username,
                lib_password = Librarian.lib_password,
                Name = Librarian.Name,
                Email = Librarian.Email,
                Phonenumber = Librarian.Phonenumber,
                NIC = Librarian.NIC,
                ImagePath = Librarian.ImagePath,
                repeat_password = Librarian.repeat_password
            };
            var dt = lib.tbl_librarian.Where(x => x.lib_username == Librarian.lib_username).FirstOrDefault();
            if (dt != null)
            {
                return false;
            }
            else
            {
                lib.tbl_librarian.Add(data);
                lib.SaveChanges();
                tblLogin login = new tblLogin()
                {
                    lib_id = data.lib_id,
                    log_pasword = data.lib_password
                };
                lib.tblLogins.Add(login);
                lib.SaveChanges();
                return true;
            }


        }
        
        public int[] getnextid(LibrarianModel Librarian)
        {
            int[] values = new int[2];
            try
            {

                int lib_id = lib.tbl_librarian.Max(x => x.lib_id) + 1;
                Librarian.lib_id = lib_id;

                Librarian.logininfo = new LoginModel() { Loginid = lib.tblLogins.Max(x => x.Loginid) + 1 };


                values[0] = lib_id;
                values[1] = Librarian.logininfo.Loginid;
                return values;

            }
            catch (Exception)
            {
                values[0] = 0;
                values[1] = 0;
                return values;

            }


        }

        public List<LibrarianModel> ViewLibrarian()
        {
            List<LibrarianModel> Librarian = (from q in lib.tbl_librarian
                                              select new LibrarianModel
                                              {
                                                  lib_id = q.lib_id,
                                                  lib_username = q.lib_username,
                                                  lib_password = q.lib_password,
                                                  Name = q.Name,
                                                  Email = q.Email,
                                                  Phonenumber = q.Phonenumber,
                                                  NIC = q.NIC,
                                                  ImagePath = q.ImagePath,
                                                  repeat_password = q.repeat_password
                                              }).ToList();
            return Librarian;
        }

        public LibrarianModel GetOneLibrarian(int Fid)
        {
            var logindata = (from q in lib.tblLogins
                             where q.lib_id == Fid
                             select new MemberModel
                             {
                                 logininfo = new LoginModel()
                                 {
                                     Loginid = q.Loginid
                                 }
                             }).FirstOrDefault();

            var data = (from q in lib.tbl_librarian
                        where q.lib_id == Fid
                        select new LibrarianModel
                        {
                            lib_id = q.lib_id,
                            lib_username = q.lib_username,
                            lib_password = q.lib_password,
                            Name = q.Name,
                            Email = q.Email,
                            Phonenumber = q.Phonenumber,
                            NIC = q.NIC,
                            ImagePath = q.ImagePath,
                            repeat_password = q.repeat_password,
                            logininfo = new LoginModel() { Loginid = logindata.logininfo.Loginid }
                        }).FirstOrDefault();
            return data;
        }
        public bool UpdateLibrarian(LibrarianModel Librarian)
        {

            var data = lib.tbl_librarian.Where(m => m.lib_id == Librarian.lib_id).FirstOrDefault();
            data.Name = Librarian.Name;
            data.lib_password = Librarian.lib_password;
            data.Name = Librarian.Name;
            data.Email = Librarian.Email;
            data.Phonenumber = Librarian.Phonenumber;
            data.NIC = Librarian.NIC;
            data.ImagePath = Librarian.ImagePath;
            data.repeat_password = Librarian.repeat_password;
            try
            {
                lib.SaveChanges();
                var login = lib.tblLogins.Where(x => x.Loginid == Librarian.logininfo.Loginid).FirstOrDefault();
                login.log_pasword = Librarian.lib_password;
                lib.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteLibrarian(int Fid)
        {
            var data = lib.tbl_librarian.Where(x => x.lib_id == Fid).FirstOrDefault();
            lib.tbl_librarian.Remove(data);
            try
            {
                lib.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }







        //start
    }
}