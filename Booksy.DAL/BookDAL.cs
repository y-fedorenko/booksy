using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booksy.Models;

namespace Booksy.DAL
{
    public class BookDAL
    {
        public class Placeholder { }
        public readonly BooksyDbContext _context;
        public BookDAL(BooksyDbContext context)
        {
            _context = context;
        }
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books;
        }
        public Book GetBook(int BookID)
        {
            return _context.Books.Find(BookID);
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int BookID)
        {
            Book book = _context.Books.Find(BookID);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}
