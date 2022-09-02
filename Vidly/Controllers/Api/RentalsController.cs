using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models.DataTransferObjects;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostRental(RentalDto rentalDto)
        {
            return NoContent();
        }
    }
}
