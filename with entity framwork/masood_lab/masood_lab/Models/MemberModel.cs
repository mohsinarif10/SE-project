using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masood_lab.Models
{
    public class MemberModel
    {
        public int memberID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Date_of_birth { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public bool Csharp { get; set; }
        public bool python { get; set; }
        public bool JAVA { get; set; }
        



    }
}