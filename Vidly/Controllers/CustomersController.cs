using Microsoft.AspNetCore.Mvc;
using Vidly.ViewModels;
using Vidly.Services;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersDataService _service;

        public CustomersController(ICustomersDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetItemsAsync());
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var customer = await _service.GetItemByIdAsync(id);
            return customer != null ? View(customer) : NotFound();
        }

        public async Task<IActionResult> New()
        {
            var membershipTypes = await _service.GetMembershipTypesAsync();
            return View(new NewCustomerViewModel { MembershipTypes = membershipTypes });
        }
    }
}
