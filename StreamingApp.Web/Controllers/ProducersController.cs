using Microsoft.AspNetCore.Mvc;
using StreamingApp.Data.Entities;
using StreamingApp.Services;
using StreamingApp.Web.ViewModels;

namespace StreamingApp.Web.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await _producerService.GetAllProducersAsync();
            return View(producers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProducerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var producer = new Producer
                {
                    Name = viewModel.Name
                };

                await _producerService.AddProducerAsync(producer);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producerService.GetProducersByIdAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            var viewModel = new ProducerEditViewModel
            {
                Id = producer.Id,
                Name = producer.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProducerEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var producer = new Producer
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name
                };

                await _producerService.UpdateProducerAsync(producer);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _producerService.GetProducersByIdAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //await _producerService.DeleteProducerAsync(id);
            //return RedirectToAction(nameof(Index));
            var producer = await _producerService.GetProducersByIdAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            await _producerService.DeleteProducerAsync(id);
            TempData["Message"] = $"La productora '{producer.Name}' ha sido eliminada exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
    
}