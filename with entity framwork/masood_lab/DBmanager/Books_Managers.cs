using masood_lab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace masood_lab.DBmanager
{
    public class Books_Managers : General
    {   
        public bool AddBook(BooksModel books)
        {
            
            tblNewBooks_registration data = new tblNewBooks_registration()
            {
                BookName = books.BookName,
                BookAuthor = books.BookAuthor,
                BookPublisher = books.BookPublisher,
                BookPrice = books.BookPrice,
                BookCategory = books.BooksCategoryID,
                ImagePath=books.ImagePath
            };
            lib.tblNewBooks_registration.Add(data);
            try
            {
                lib.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }

        public List<BooksModel> ViewBooks()
        {
            List<BooksModel> data = (from books in lib.tblNewBooks_registration
                                     select new BooksModel
                                         {
                                             BookID = books.BookID,
                                             BookName = books.BookName,
                                             BookAuthor = books.BookAuthor,
                                             BookPublisher = books.BookPublisher,
                                             BookPrice = books.BookPrice,
                                             BooksCategory = books.tblBooksCategory.CategoryName
                                         }).ToList();
            return data;
        }
        
        public int nextid(BooksModel books)
        {
            try
            {
                int data = lib.tblNewBooks_registration.Max(x => x.BookID) + 1;
                books.BookID = data;
                return data;
            }
            catch (Exception)
            {
                int data = 0;
                return data;
            }
           
        }

        public BooksModel GetOneBook(int Fid)
        {
            var data = (from books in lib.tblNewBooks_registration
                        where books.BookID == Fid
                        select new BooksModel
                            {
                                BookID = books.BookID,
                                BookName = books.BookName,
                                BookAuthor = books.BookAuthor,
                                BookPublisher = books.BookPublisher,
                                BookPrice = books.BookPrice,
                                BooksCategoryID = books.BookCategory,
                                BooksCategory=books.tblBooksCategory.CategoryName,
                                ImagePath=books.ImagePath
                            }).FirstOrDefault();
            return data;
        }

      
        public bool UpdateBook(BooksModel books)
        {
            try
            {         
                 var data = lib.tblNewBooks_registration.Where(x => x.BookID == books.BookID).FirstOrDefault();
                 data.BookID = books.BookID;
                 data.BookName = books.BookName;
                 data.BookAuthor = books.BookAuthor;
                 data.BookPublisher = books.BookPublisher;
                 data.BookPrice = books.BookPrice;
                 data.BookCategory = books.BooksCategoryID;
                 data.ImagePath = books.ImagePath;
                 lib.SaveChanges();
                   return true;
            }
            catch (Exception)
            {

                return false;
            }     
        }

        public bool DeleteBook(int Fid)
        {
            var data = lib.tblNewBooks_registration.Where(x => x.BookID == Fid).FirstOrDefault();
            lib.tblNewBooks_registration.Remove(data); 
            try
            {        
                lib.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }




       

    }
}