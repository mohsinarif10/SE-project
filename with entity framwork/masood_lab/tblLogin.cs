//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace masood_lab
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLogin
    {
        public int Loginid { get; set; }
        public Nullable<int> memberID { get; set; }
        public Nullable<int> lib_id { get; set; }
        public Nullable<int> admin_id { get; set; }
        public string log_pasword { get; set; }
    
        public virtual tbl_admin tbl_admin { get; set; }
        public virtual tbl_librarian tbl_librarian { get; set; }
        public virtual tblNewMembers_registration tblNewMembers_registration { get; set; }
    }
}
