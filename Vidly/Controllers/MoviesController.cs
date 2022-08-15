using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Services;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesDataService _service;

        public MoviesController(IMoviesDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetItemsAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetItemByIdAsync(id);
            return movie != null ? View(movie) : NotFound();
        }

        public async Task<IActionResult> New()
        {
            return View("MovieForm", new MovieFormViewModel { Genres = await _service.GetGenresAsync() });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetItemByIdAsync(id);
            return movie != null ? View("MovieForm", new MovieFormViewModel { Movie = movie, Genres = await _service.GetGenresAsync() }) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Movie movie)
        {
            if (movie.Id == 0) await _service.AddItemAsync(movie);
            else await _service.UpdateItemAsync(movie);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}
