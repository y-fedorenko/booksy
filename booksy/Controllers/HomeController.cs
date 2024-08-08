using Booksy.BLL;
using Booksy.Models;
using Booksy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Booksy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        public HomeController(ILogger<HomeController> logger, BookService bookService, AuthorService authorService)
        {
            _logger = logger;
            _bookService = bookService;
            _authorService = authorService;
        }

         

        public async Task<IActionResult> Index()
        {
            var books = _bookService.GetBooks();
            var authors = await _authorService.GetAllAuthorsAsync();

            var viewModel = new BooksAndAuthorsViewModel
            {
                Books = books,
                Authors = authors
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
