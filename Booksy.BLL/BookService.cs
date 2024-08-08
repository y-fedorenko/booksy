using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booksy.Models;
using Booksy.DAL;
using Microsoft.EntityFrameworkCore;

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
        public Book GetBook(int BookID)
        {
            return _bookDAL.GetBook(BookID);
        }
        public List<Book> GetBooks() {
            return _bookDAL.GetBooks();
        }
        public IEnumerable<Book> GetBooksAll() {
            return _bookDAL.GetBooks();
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

        public async Task<List<Book>> GetBooksBySerieIdAsync(int serieId)
        {
            return await _bookDAL.GetBooksBySerieIdAsync(serieId);
        }
    }
}
