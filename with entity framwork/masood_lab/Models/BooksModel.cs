using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masood_lab.Models
{
    public class BooksModel
    {

        public int BookID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookAuthor { get; set; }
        [Required]
        public string BookPublisher { get; set; }
        [Required]
        public string BookPrice { get; set; }
        public string BooksCategory { get; set; }

        [Required]  
        public int BooksCategoryID { get; set; }

        public string ImagePath { get; set; }


        public static IList<SelectListItem> bookscategory()
        {
            Library_systemEntities1 lib = new Library_systemEntities1();
            IList<SelectListItem> data = (from q in lib.tblBooksCategories
                                          select new SelectListItem
                                          {
                                              Text = q.CategoryName,
                                              Value = q.ID.ToString(),
                                              Selected = false
                                          }).ToList();
            return data;
        }
      




    }
}