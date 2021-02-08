using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace masood_lab.Models
{
    public class LoginModel
    {
        public int Loginid { get; set; }
        public string  login_password { get; set; }

        public int id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public MemberModel member_model { get; set; }
        public LibrarianModel librarian_model { get; set; }
        public AdminModel admin_model { get; set; }
        public string identification { get; set; }




        


        
         

    }
}