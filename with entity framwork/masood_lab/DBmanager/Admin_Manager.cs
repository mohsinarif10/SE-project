using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masood_lab.DBmanager
{
    public class Admin_Manager : General
    {
        //start

        public bool AddAdmin(AdminModel Admin)
        {

            tbl_admin data = new tbl_admin()
            {
                admin_username = Admin.admin_username,
                admin_Name = Admin.admin_Name,
                admin_password = Admin.admin_password,
                ImagePath = Admin.ImagePath
            };

            var dt = lib.tbl_admin.Where(x => x.admin_username == Admin.admin_username).FirstOrDefault();
            if (dt != null)
            {
                return false;
            }
            else
            {
                lib.tbl_admin.Add(data);
                lib.SaveChanges();
                tblLogin login = new tblLogin()
                {
                    admin_id = data.admin_id,
                    log_pasword = data.admin_password
                };
                lib.tblLogins.Add(login);
                lib.SaveChanges();
                return true;
            }

        }
        public int[] getnextid(AdminModel Admin)
        {
            int[] values = new int[2];
            try
            {

                int admin_id = lib.tblNewMembers_registration.Max(x => x.memberID) + 1;
                Admin.admin_id = admin_id;

                Admin.logininfo = new LoginModel() { Loginid = lib.tblLogins.Max(x => x.Loginid) + 1 };


                values[0] = admin_id;
                values[1] = Admin.logininfo.Loginid;
                return values;

            }
            catch (Exception)
            {
                values[0] = 0;
                values[1] = 0;
                return values;

            }




            //end
        }
    }
}