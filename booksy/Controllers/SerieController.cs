using Booksy.BLL;
using Booksy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Booksy.Controllers
{
    public class SerieController : Controller
    {
        private readonly SerieService _serieService;
        private readonly BookService _bookService;

        public SerieController(SerieService serieService, BookService bookService)
        {
            _serieService = serieService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetSeriesAsync();
            return View(series);
        }

        public async Task<IActionResult> Details(int serieId)
        {
            var serie = await _serieService.GetSerieAsync(serieId);
            if (serie == null)
            {
                return NotFound();
            }
            serie.Books = ( _bookService.GetBooks()).Where(b => b.SeriesId == serieId).ToList();
            return View(serie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var serieVM = new SerieViewModel();
            return View(serieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SerieViewModel serieVM)
        {
            if (ModelState.IsValid)
            {
                var serie = new Serie
                {
                    SeriesName = serieVM.SeriesName,
                    SeriesDescription = serieVM.SeriesDescription
                };

                await _serieService.AddSerieAsync(serie);
                return RedirectToAction("Index");
            }
            return View(serieVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int serieId)
        {
            var serie = await _serieService.GetSerieAsync(serieId);
            if (serie == null)
            {
                return NotFound();
            }

            var serieVM = new SerieViewModel
            {
                SerieId = serie.SeriesId,
                SeriesName = serie.SeriesName,
                SeriesDescription = serie.SeriesDescription,
                Books = ( _bookService.GetBooks()).Where(b => b.SeriesId == serieId).ToList()
            };
            return View(serieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SerieViewModel serieVM)
        {
            if (ModelState.IsValid)
            {
                var serie = await _serieService.GetSerieAsync(serieVM.SerieId);
                if (serie == null)
                {
                    return NotFound();
                }

                serie.SeriesName = serieVM.SeriesName;
                serie.SeriesDescription = serieVM.SeriesDescription;

                await _serieService.UpdateSerieAsync(serie);
                return RedirectToAction("Index");
            }
            serieVM.Books = ( _bookService.GetBooks()).Where(b => b.SeriesId == serieVM.SerieId).ToList();
            return View(serieVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int serieId)
        {
            var serie = await _serieService.GetSerieAsync(serieId);
            if (serie == null)
            {
                return NotFound();
            }
            serie.Books = ( _bookService.GetBooks()).Where(b => b.SeriesId == serieId).ToList();
            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int serieId)
        {
            var serie = await _serieService.GetSerieAsync(serieId);
            if (serie == null)
            {
                return NotFound();
            }

            await _serieService.DeleteSerieAsync(serieId);
            return RedirectToAction("Index");
        }
    }
}
