using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Services;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerDataService _service;

        public CustomersController(ICustomerDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetItemsAsync());
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            return customer != null ? View(customer) : NotFound();
        }
    }
}
