using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Helpers;
using Vidly.Models;
using Vidly.Models.DataTransferObjects;
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

        public IActionResult Index()
        {
            if (User.IsInRole(Constants.StoreManagerRoleName))
                return View("MoviesList");

            return View("MoviesReadOnlyList");
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetItemByIdAsync(id);
            return movie != null ? View(movie) : NotFound();
        }

        [Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> New()
        {
            return View("MovieForm", new MovieFormViewModel { Genres = await _service.GetGenresAsync() });
        }

        [Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetItemByIdAsync(id);
            return movie != null ? View("MovieForm", new MovieFormViewModel { Movie = MovieDto.ConvertToDto(movie), Genres = await _service.GetGenresAsync() }) : NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Save(MovieDto movie)
        {
            if(!ModelState.IsValid) return View("MovieForm", new MovieFormViewModel { Movie = movie, Genres = await _service.GetGenresAsync() });

            if (movie.Id == 0) await _service.AddItemAsync(movie.ConvertToModel());
            else await _service.UpdateItemAsync(movie.Id, movie.ConvertToModel());

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete, Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
