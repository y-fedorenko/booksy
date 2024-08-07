using Booksy.Models;
using Booksy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booksy.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Biography,ImageUrl")] Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.AddAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FirstName,LastName,Biography,ImageUrl")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _authorService.UpdateAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Author/Index
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }
    }
}
