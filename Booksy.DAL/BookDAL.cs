using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booksy.Models;
using Microsoft.EntityFrameworkCore;

namespace Booksy.DAL
{
    public class BookDAL {
        public class Placeholder { }
        private readonly BooksyDbContext _context;
        public BookDAL(BooksyDbContext context) {
            _context = context;
        }
        public Book GetBook(int BookId) {
            return _context.Books.Include(b => b.Author)
                                .Include(b => b.Serie)
                                .Include(b => b.Comments)
                                .FirstOrDefault(b => b.BookId == BookId);
        }
        public List<Book> GetBooks() {
            return _context.Books.Include(b => b.Author)
                                .Include(b => b.Serie)
                                .Include(b => b.Comments)
                                .ToList();
        }
        public IEnumerable<Book> GetAllBooks() {
            return _context.Books;
        }
        public void AddBook(Book book) {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book) {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int BookID) {
            var book = _context.Books.Find(BookID);
            if (book != null) {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
