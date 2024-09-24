using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingApp.Data.Entities;
using StreamingApp.Services;
using StreamingApp.Web.ViewModels;

namespace StreamingApp.Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProducerService _producerService;
        private readonly IGenreService _genreService;

        public SeriesController(ISerieService serieService, IProducerService producerService, IGenreService genreService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetAllSeriesAsync();
            var viewModel = series.Select(s => new SerieListViewModel
            {
                Id = s.Id,
                Name = s.Name,
                CoverImage = s.CoverImage,
                Producer = s.Producer.Name,
                Genre = $"{s.PrimaryGenre.Name}{(s.SecondaryGenre != null ? $", {s.SecondaryGenre.Name}" : "")}"
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new SerieCreateViewModel
            {
                Producers = new SelectList(await _producerService.GetAllProducersAsync(), "Id", "Name"),
                Genres = new SelectList(await _genreService.GetAllGenreAsync(), "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SerieCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var serie = new Serie
                {
                    Name = viewModel.Name,
                    CoverImage = viewModel.CoverImage,
                    VideoLink = viewModel.VideoLink,
                    ProducerId = viewModel.ProducerId,
                    PrimaryGenreId = viewModel.PrimaryGenreId,
                    SecondaryGenreId = viewModel.SecondaryGenreId
                };

                await _serieService.AddSerieAsync(serie);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Producers = new SelectList(await _producerService.GetAllProducersAsync(), "Id", "Name");
            viewModel.Genres = new SelectList(await _genreService.GetAllGenreAsync(), "Id", "Name");
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serie = await _serieService.GetSerieByIdAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            var viewModel = new SerieEditViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                CoverImage = serie.CoverImage,
                VideoLink = serie.VideoLink,
                ProducerId = serie.ProducerId,
                PrimaryGenreId = serie.PrimaryGenreId,
                SecondaryGenreId = serie.SecondaryGenreId,
                Producers = new SelectList(await _producerService.GetAllProducersAsync(), "Id", "Name"),
                Genres = new SelectList(await _genreService.GetAllGenreAsync(), "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SerieEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var serie = new Serie
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    CoverImage = viewModel.CoverImage,
                    VideoLink = viewModel.VideoLink,
                    ProducerId = viewModel.ProducerId,
                    PrimaryGenreId = viewModel.PrimaryGenreId,
                    SecondaryGenreId = viewModel.SecondaryGenreId
                };

                await _serieService.UpdateSerieAsync(serie);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Producers = new SelectList(await _producerService.GetAllProducersAsync(), "Id", "Name");
            viewModel.Genres = new SelectList(await _genreService.GetAllGenreAsync(), "Id", "Name");
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serie = await _serieService.GetSerieByIdAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serieService.DeleteSerieAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}