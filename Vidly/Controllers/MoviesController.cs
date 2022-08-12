using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View(GetMovies());
        }

        private static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new() { Id = 1, Title = "Shrek!" },
                new() { Id = 2, Title = "Wall-E" }
            };
        }
    }
}
