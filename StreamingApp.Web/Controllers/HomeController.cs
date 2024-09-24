using Microsoft.AspNetCore.Mvc;
using StreamingApp.Data.Entities;
using StreamingApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingApp.Web.Models;
using StreamingApp.Web.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace StreamingApp.Web.Controllers
{

        public class HomeController : Controller
        {
            private readonly ISerieService _serieService;
            private readonly IProducerService _producerService;
            private readonly IGenreService _genreService;

            public HomeController(ISerieService serieService, IProducerService producerService, IGenreService genreService)
            {
                _serieService = serieService;
                _producerService = producerService;
                _genreService = genreService;
            }

            public async Task<IActionResult> Index(string search, int? producerId, int? genreId)
            {
                var series = await _serieService.GetAllSeriesAsync();
                var producers = await _producerService.GetAllProducersAsync();
                var genres = await _genreService.GetAllGenreAsync();

                if (!string.IsNullOrEmpty(search))
                {
                    series = await _serieService.SearchSeriesByNameAsync(search);
                }
                else if (producerId.HasValue)
                {
                    series = await _serieService.FilterSeriesByProducerAsync(producerId.Value);
                }
                else if (genreId.HasValue)
                {
                    series = await _serieService.FilterSeriesByGenreAsync(genreId.Value);
                }

                var viewModel = new HomeViewModel
                {
                    Series = series.Select(s => new SerieListViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        CoverImage = s.CoverImage,
                        Producer = s.Producer.Name,
                        Genre = $"{s.PrimaryGenre.Name}{(s.SecondaryGenre != null ? $", {s.SecondaryGenre.Name}" : "")}"
                    }).ToList(),
                    Producers = new SelectList(producers, "Id", "Name"),
                    Genres = new SelectList(genres, "Id", "Name"),
                    Search = search,
                    SelectedProducerId = producerId,
                    SelectedGenreId = genreId
                };

                return View(viewModel);
            }

            public async Task<IActionResult> Details(int id)
            {
                var serie = await _serieService.GetSerieByIdAsync(id);
                if (serie == null)
                {
                    return NotFound();
                }

                var viewModel = new DetailsSerieViewModel
                {
                    Serie = serie
                };

                return View(viewModel);
            }
        }



        #region original home
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        #endregion

    
}
