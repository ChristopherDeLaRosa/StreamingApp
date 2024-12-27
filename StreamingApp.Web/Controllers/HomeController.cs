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
            if (producerId.HasValue)
            {
                series = series.Where(s => s.Producer.Id == producerId.Value);
            }
            if (genreId.HasValue)
            {
                series = series.Where(s => s.PrimaryGenre.Id == genreId.Value || (s.SecondaryGenre != null && s.SecondaryGenre.Id == genreId.Value));
            }

            var viewModel = new FilterViewModel
            {
                Series = series.Select(s => new SerieListViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CoverImage = s.CoverImage,
                    Producer = s.Producer.Name,
                    Genre = $"{s.PrimaryGenre.Name}{(s.SecondaryGenre != null ? $", {s.SecondaryGenre.Name}" : "")}"
                }).ToList(),
                Producers = producers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList(),
                Genres = genres.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList(),
                Search = search,
                SelectedProducerId = producerId,
                SelectedGenreId = genreId
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FilterViewModel model)
        {
            return await Index(model.Search, model.SelectedProducerId, model.SelectedGenreId);
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
                Serie = serie,
                Producer = serie.Producer,
                PrimaryGenre = serie.PrimaryGenre,
                SecondaryGenre = serie.SecondaryGenre

            };

            return View(viewModel);
        }
        

    }


}


