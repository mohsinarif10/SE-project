using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace masood_lab.Models
{
    public class MemberModel
    {
        public int loginid_test { get; set; }

        public int memberID { get; set; }

        [Required]
        public string member_username { get; set; }

        [Required]
        public string Fullname { get; set; }
       
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must contain 11 digits")]
        public string Phonenumber { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "NIC must contain 13 digits")]
        public string NIC { get; set; }
        public string Address { get; set; }
         [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Date_of_birth { get; set; }
         [Required]
         [StringLength(15, MinimumLength = 4 ,ErrorMessage = "password must contain 4 to 15 letters")]
        public string Password { get; set; }
         [Required]
         [StringLength(15, MinimumLength = 4)]
         [CompareAttribute("Password", ErrorMessage = "password did'nt match")]
        public string RepeatPassword { get; set; }   
        public string Gender { get; set; }

        public string ImagePath { get; set; }

        public static string secondimange { get; set; }

        public LoginModel logininfo { get; set; }

      


      
    }
}