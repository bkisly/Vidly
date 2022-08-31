using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Services;
using Vidly.Models.DataTransferObjects;
using Vidly.Helpers;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesDataService _service;

        public MoviesController(IMoviesDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var customers = await _service.GetItemsAsync();
            return Ok(customers.Select(m => MovieDto.ConvertToDto(m)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var customer = await _service.GetItemByIdAsync(id);
            return customer != null ? Ok(MovieDto.ConvertToDto(customer)) : NotFound();
        }

        [HttpPost, Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = movieDto.ConvertToModel();
            await _service.AddItemAsync(movie);
            return CreatedAtAction(nameof(PostMovie), new { id = movie.Id }, MovieDto.ConvertToDto(movie));
        }

        [HttpPut("{id}"), Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _service.UpdateItemAsync(id, movieDto.ConvertToModel());
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteItemAsync(id);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
