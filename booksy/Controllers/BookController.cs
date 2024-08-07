using Microsoft.AspNetCore.Mvc;
using Booksy.BLL;
using Booksy.Models;


namespace Booksy.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        public BookController(BookService bookService) {
            _bookService = bookService;
        }

        public IActionResult Index() {
            var books = _bookService.GetBooks();
            return View(books);
        }
        public IActionResult Details(int BookID) { 
            var book = _bookService.GetBook(BookID);
            if (book == null) {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Create() {
            return View();
        }
        public IActionResult Create([Bind("BookID,Title,Author,Genre,Price")] Book book) {
            if (ModelState.IsValid) {
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Edit(int BookID) {
            var book = _bookService.GetBook(BookID);
            if (book == null) {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Edit(int BookID, [Bind("BookID,Title,Author,Genre,Price")] Book book) {
            if (BookID != book.BookID) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Delete(int BookID) {
            var book = _bookService.GetBook(BookID);
            if (book == null) {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult DeleteConfirmed(int BookID) {
            _bookService.DeleteBook(BookID);
            return RedirectToAction(nameof(Index));
        }


    }
}
