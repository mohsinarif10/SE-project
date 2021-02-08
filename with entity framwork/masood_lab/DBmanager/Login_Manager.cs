using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace masood_lab.DBmanager
{
    public class Login_Manager : General
    {


        public bool LoginFunc(LoginModel logindata)
        {
            var login = lib.tblLogins.Where(x => x.Loginid == logindata.Loginid && x.log_pasword == logindata.login_password).FirstOrDefault();
            if (login != null)
            {
                if (loginInfo(logindata))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        public bool loginInfo(LoginModel logindata)
        {
            var login = lib.tblLogins.Where(x => x.Loginid == logindata.Loginid && x.log_pasword == logindata.login_password).FirstOrDefault();
            if (login.memberID != null)
            {
                var memberDB = lib.tblNewMembers_registration.Where(x => x.memberID == login.memberID).FirstOrDefault();
                logindata.id = memberDB.memberID;
                logindata.Name = memberDB.FullName;
                logindata.ImagePath = memberDB.ImagePath;
                logindata.identification = "member";
                return true;
            }
            else if (login.lib_id != null)
            {
                var LibDB = lib.tbl_librarian.Where(x => x.lib_id == login.lib_id).FirstOrDefault();
                logindata.id = LibDB.lib_id;
                logindata.Name = LibDB.Name;
                logindata.ImagePath = LibDB.ImagePath;
                logindata.identification = "librarian";
                return true;
            }
            else if (login.admin_id != null)
            {
                var adminDB = lib.tbl_admin.Where(x => x.admin_id == login.admin_id).FirstOrDefault();
                logindata.id = adminDB.admin_id;
                logindata.Name = adminDB.admin_Name;
                logindata.ImagePath = adminDB.ImagePath;
                logindata.identification = "admin";
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}