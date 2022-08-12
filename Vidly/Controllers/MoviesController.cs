using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IDataService<Movie> _service;

        public MoviesController(IDataService<Movie> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetItemsAsync());
        }
    }
}
