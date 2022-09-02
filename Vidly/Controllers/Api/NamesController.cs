using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Services;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly ICustomersDataService _customersService;
        private readonly IMoviesDataService _moviesService;

        public NamesController(ICustomersDataService customersService, IMoviesDataService moviesService)
        {
            _customersService = customersService;
            _moviesService = moviesService;
        }

        [HttpGet, Route("customers")]
        public async Task<ActionResult<IEnumerable<string>>> GetCustomersNames([FromQuery]string term)
        {
            var customers = await _customersService.GetItemsAsync();
            return customers.Select(c => c.Name).Where(name => name.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToArray();
        }

        [HttpGet, Route("movies")]
        public async Task<ActionResult<IEnumerable<string>>> GetMoviesNames([FromQuery]string term)
        {
            var movies = await _moviesService.GetItemsAsync();
            return movies.Select(m => m.Title).Where(title => title.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToArray();
        }
    }
}
