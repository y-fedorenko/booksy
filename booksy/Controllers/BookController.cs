using Microsoft.AspNetCore.Mvc;
using Booksy.DAL;
using Booksy.BLL;
using Booksy.Models;
using Booksy.ViewModels;


namespace Booksy.Controllers {
    public class BookController : Controller {
        private readonly BookService _bookService;
        private readonly AuthorDAL _authorDAL;
        private readonly SerieDAL _serieDAL;
        public BookController(BookService bookService, AuthorDAL authorDAL, SerieDAL serieDAL) {
            _bookService = bookService;
            _authorDAL = authorDAL;
            _serieDAL = serieDAL;
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
        [HttpGet]
        public async Task<IActionResult> Create() {
            var ViewModel = new BookCreateViewModel {
                Book = new Book(),
                Authors = await _authorDAL.GetAllAuthorsAsync(),
                //Series = await _serieDAL.GetSeries()
            };
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel ViewModel) {
            if (ModelState.IsValid) {
                _bookService.AddBook(ViewModel.Book);
                return RedirectToAction("Index");
            }
            ViewModel.Authors = await _authorDAL.GetAllAuthorsAsync();
           // ViewModel.Series = await _serieDAL.GetSeries();
            return View(ViewModel);
        }
        public IActionResult Add([Bind("BookID,Title,Author,Genre,Price")] Book book) {
            if (ModelState.IsValid) {
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Edit(int BookID) {
            var book = _bookService.GetBook(BookID);
            if (book == null) {
                return NotFound();
            }
            // You may need to load authors and series here if you are displaying dropdowns
            // var authors = _authorDAL.GetAllAuthorsAsync();
            // var series = _serieDAL.GetAllSeriesAsync();

            // var viewModel = new BookEditViewModel
            // {
            //     Book = book,
            //     Authors = authors,
            //     Series = series
            // };

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int BookID, [Bind("BookID,Title,Author,Genre,Price")] Book book) {
            if (BookID != book.BookId) {
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
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookID) {
            _bookService.DeleteBook(BookID);
            return RedirectToAction(nameof(Index));
        }


    }
}
