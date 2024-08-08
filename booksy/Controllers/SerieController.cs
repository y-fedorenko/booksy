using Booksy.BLL;
using Booksy.Models;
using Microsoft.AspNetCore.Mvc;

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

        serie.Books = await _bookService.GetBooksBySerieIdAsync(serieId);

        return View(serie);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SerieViewModel serieViewModel)
    {
        if (ModelState.IsValid)
        {
            var serie = new Serie
            {
                SeriesName = serieViewModel.SeriesName,
                SeriesDescription = serieViewModel.SeriesDescription,
            };

            await _serieService.AddSerieAsync(serie);
            return RedirectToAction(nameof(Index));
        }
        return View(serieViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int serieId)
    {
        var serie = await _serieService.GetSerieAsync(serieId);
        if (serie == null)
        {
            return NotFound();
        }

        var serieViewModel = new SerieViewModel
        {
            SerieId = serie.SeriesId,
            SeriesName = serie.SeriesName,
            SeriesDescription = serie.SeriesDescription,
            Books = serie.Books
        };

        return View(serieViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SerieViewModel serieViewModel)
    {
        if (ModelState.IsValid)
        {
            var serie = new Serie
            {
                SeriesId = serieViewModel.SerieId,
                SeriesName = serieViewModel.SeriesName,
                SeriesDescription = serieViewModel.SeriesDescription,
                Books = serieViewModel.Books
            };
            await _serieService.UpdateSerieAsync(serie);
            return RedirectToAction(nameof(Details), new { serieId = serie.SeriesId });
        }

        return View(serieViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int serieId)
    {
        var serie = await _serieService.GetSerieAsync(serieId);
        if (serie == null)
        {
            return NotFound();
        }

        return View(serie);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int serieId)
    {
        var serie = await _serieService.GetSerieAsync(serieId);
        if (serie == null)
        {
            return NotFound();
        }

        await _serieService.DeleteSerieAsync(serieId);
        return RedirectToAction(nameof(Index));
    }
}
