using Microsoft.AspNetCore.Mvc;
using Booksy.DAL;
using Booksy.BLL;
using Booksy.Models;
using Booksy.ViewModels;

namespace Booksy.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly AuthorDAL _authorDAL;
        private readonly SerieDAL _serieDAL;
        private readonly CommentService _commentService;

        public BookController(BookService bookService, AuthorDAL authorDAL, SerieDAL serieDAL, CommentService commentService)
        {
            _bookService = bookService;
            _authorDAL = authorDAL;
            _serieDAL = serieDAL;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult Details(int BookId)
        {
            var book = _bookService.GetBook(BookId);
            if (book == null)
            {
                return NotFound();
            }

            var comment = new Comment { BookId = BookId };
            var viewModel = new BookDetailsViewModel
            {
                Book = book,
                NewComment = comment,
                EditComment = null
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ViewModel = new BookCreateViewModel
            {
                Book = new Book(),
                Authors = await _authorDAL.GetAllAuthorsAsync(),
                Series = await _serieDAL.GetSeriesAsync()
            };
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(ViewModel.Book);
                return RedirectToAction("Index");
            }
            ViewModel.Authors = await _authorDAL.GetAllAuthorsAsync();
            ViewModel.Series = await _serieDAL.GetSeriesAsync();
            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int BookID)
        {
            var book = _bookService.GetBook(BookID);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int BookID, [Bind("BookID,Title,Author,Genre,Price")] Book book)
        {
            if (BookID != book.BookId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int BookID)
        {
            var book = _bookService.GetBook(BookID);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BookID)
        {
            _bookService.DeleteBook(BookID);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(BookDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _commentService.AddCommentAsync(viewModel.NewComment);
                return RedirectToAction("Details", new { BookId = viewModel.NewComment.BookId });
            }

            viewModel.Book = _bookService.GetBook(viewModel.NewComment.BookId);
            return View("Details", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(BookDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _commentService.UpdateCommentAsync(viewModel.EditComment);
                return RedirectToAction("Details", new { BookId = viewModel.EditComment.BookId });
            }

            viewModel.Book = _bookService.GetBook(viewModel.EditComment.BookId);
            return View("Details", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId, int bookId)
        {
            await _commentService.DeleteCommentAsync(commentId);
            return RedirectToAction("Details", new { BookId = bookId });
        }
    }
}
