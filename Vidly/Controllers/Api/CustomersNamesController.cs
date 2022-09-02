using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Services;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersNamesController : ControllerBase
    {
        private readonly ICustomersDataService _serivce;

        public CustomersNamesController(ICustomersDataService serivce)
        {
            _serivce = serivce;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCustomersNames([FromQuery]string term)
        {
            var customers = await _serivce.GetItemsAsync();
            return customers.Select(c => c.Name).Where(name => name.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToArray();
        }
    }
}
