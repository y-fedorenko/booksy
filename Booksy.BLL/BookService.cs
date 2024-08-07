using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booksy.Models;
using Booksy.DAL;

namespace Booksy.BLL
{
    public class BookService
    {
        public class Placeholder { }
        private readonly BookDAL _bookDAL;
        public BookService(BookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
        public List<Book> GetBooks()
        {
            return _bookDAL.GetBooks();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDAL.GetAllBooks();
        }
        public Book GetBook(int BookID)
        {
            return _bookDAL.GetBook(BookID);
        }
        public void AddBook(Book book)
        {
            _bookDAL.AddBook(book);
        }
        public void UpdateBook(Book book)
        {
            _bookDAL.UpdateBook(book);
        }
        public void DeleteBook(int BookID)
        {
            _bookDAL.DeleteBook(BookID);
        }
    }
}
