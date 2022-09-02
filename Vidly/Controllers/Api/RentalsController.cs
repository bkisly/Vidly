using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Models.DataTransferObjects;
using Vidly.Services;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly ICustomersDataService _customerDataService;
        private readonly IMoviesDataService _moviesDataService;
        private readonly IModifiableDataService<Rental> _rentalsDataService;

        public RentalsController(ICustomersDataService customersDataService, 
            IMoviesDataService moviesDataService, IModifiableDataService<Rental> rentalsDataService)
        {
            _customerDataService = customersDataService;
            _moviesDataService = moviesDataService;
            _rentalsDataService = rentalsDataService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostRental(RentalDto rentalDto)
        {
            var customer = await _customerDataService.GetItemByIdAsync(rentalDto.CustomerId);
            if (customer is null) throw new NullReferenceException("Given customer does not exist.");

            foreach(int movieId in rentalDto.MovieIds)
            {
                var movie = await _moviesDataService.GetItemByIdAsync(movieId);
                if (movie is null) throw new NullReferenceException("Given movie does not exist.");

                await _rentalsDataService.AddItemAsync(new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                });
            }

            return NoContent();
        }
    }
}
