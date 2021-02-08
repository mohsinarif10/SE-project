using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace masood_lab.Models
{
    public class RegistrationModel
    {

        
        public int registrationID { get; set; }

        public string BookName { get; set; }

       [Required]
        public int BooksID { get; set; }


        public string MemberName { get; set; }


        [Required]
        public int MemberID { get; set; }


        [Required]
        public string IssuedDate { get; set; }


        [Required]
        public string ExpiryDate { get; set; }

        

       




    }
}