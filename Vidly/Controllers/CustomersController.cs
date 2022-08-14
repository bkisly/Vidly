using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
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
            return View("CustomerForm", new NewCustomerViewModel { MembershipTypes = membershipTypes });
        }

        public async Task<IActionResult> Edit(int id)
        {
            Customer? customer = await _service.GetItemByIdAsync(id);
            if(customer == null) return NotFound();

            NewCustomerViewModel viewModel = new() { Customer = customer, MembershipTypes = await _service.GetMembershipTypesAsync() };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _service.AddItemAsync(customer);
            return RedirectToAction("Index");
        }
    }
}
