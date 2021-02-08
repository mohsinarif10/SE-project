using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace masood_lab.Models
{
    public class AdminModel
    {

        public int admin_id { get; set; }

        [Required]
        public string admin_Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "password must contain 4 to 15 letters")]   
        public string admin_password { get; set; }

        
         [Required]
        public string admin_username { get; set; }
        public string ImagePath { get; set; }

        public LoginModel logininfo { get; set; }


    }
}