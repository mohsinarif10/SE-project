using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace masood_lab.Models
{
    public class LibrarianModel
    {
        
        public int lib_id { get; set; }

        [Required]
        public string lib_username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "password must contain 4 to 15 letters")]
        public string lib_password { get; set; }

        [Required]
        [CompareAttribute("lib_password", ErrorMessage = "password did'nt match")]
        public string repeat_password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must contain 11 digits")]
        public string Phonenumber { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "NIC must contain 13 digits")]      
        public string NIC { get; set; }

        public string ImagePath { get; set; }

        public LoginModel logininfo { get; set; }

    }
}