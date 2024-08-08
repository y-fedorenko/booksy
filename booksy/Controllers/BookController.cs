using Microsoft.AspNetCore.Mvc;
using Booksy.BLL;
using Booksy.Models;
using Booksy.ViewModels;
using Booksy.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly CommentService _commentService;
    private readonly AuthorService _authorService;
    private readonly SerieService _serieService;

    public BookController(BookService bookService, CommentService commentService, AuthorService authorService, SerieService serieService)
    {
        _bookService = bookService;
        _commentService = commentService;
        _authorService = authorService;
        _serieService = serieService;
    }

    public IActionResult Index()
    {
        var books = _bookService.GetBooks();
        return View(books);
    }

    public IActionResult Details(int bookId)
    {
        var book = _bookService.GetBook(bookId);
        if (book == null)
        {
            return NotFound();
        }
        var viewModel = new BookDetailsViewModel
        {
            Book = book,
            Comments = book.Comments
        };
        return View(viewModel);
    }
    
    public async Task<IActionResult> Create()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        var series = await _serieService.GetSeriesAsync();

        var model = new BookViewModel
        {
            Authors = authors,

            Series = series
        };

        return View(model);
    }
    

    [HttpPost]
    public async Task<IActionResult> Create(BookViewModel bookViewModel)
    {
        if (ModelState.IsValid)
        {
            var book = new Book
            {
                Title = bookViewModel.Title,
                AuthorId = bookViewModel.AuthorId,
                Price = bookViewModel.Price,
                Category = bookViewModel.Category,
                Description = bookViewModel.Description,
                CoverUrl = bookViewModel.CoverUrl,
                DownloadUrl = bookViewModel.DownloadUrl
            };

            _bookService.AddBook(book);
            return RedirectToAction(nameof(Index));
        }
        
        return View(bookViewModel);
    }


    // GET action to display the form for adding a new comment
    [HttpGet]
	public IActionResult CreateComment(int bookId)
	{
		var viewModel = new CommentViewModel { BookId = bookId };
        viewModel.BookId = bookId;
        viewModel.CommentText = " ";
        viewModel.UserName = " ";
		return View(viewModel);
	}

	[HttpPost]
	public async Task<IActionResult> CreateComment(CommentViewModel viewModel)
	{
		if (!ModelState.IsValid)
		{
			
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			foreach (var error in errors)
			{
				Console.WriteLine(error.ErrorMessage);  
            }
			return View(viewModel);
		}

		var comment = new Comment
		{
			BookId = viewModel.BookId,
			CommentText = viewModel.CommentText,
			UserName = viewModel.UserName
		};

		await _commentService.AddCommentAsync(comment);
		return RedirectToAction("Details", new { bookId = viewModel.BookId }); 
	}


	[HttpGet]
    public async Task<IActionResult> EditComment(int id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        var viewModel = new CommentViewModel
        {
            CommentId = comment.CommentId,
            BookId = comment.BookId,
            CommentText = comment.CommentText,
            UserName = comment.UserName
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> EditComment(CommentViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var comment = await _commentService.GetCommentAsync(viewModel.CommentId);
        if (comment == null)
        {
            return NotFound();
        }

        comment.CommentText = viewModel.CommentText;
        comment.UserName = viewModel.UserName;
        await _commentService.UpdateCommentAsync(comment);

        return RedirectToAction("Details", new { bookId = comment.BookId });
    }

    [HttpGet]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return View(comment);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCommentConfirmed(int id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        await _commentService.DeleteCommentAsync(id);
        return RedirectToAction("Details", new { bookId = comment.BookId });  // Redirect back to the details page
    }

}
