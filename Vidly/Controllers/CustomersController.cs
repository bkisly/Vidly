using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View(GetCustomers());
        }

        public IActionResult Details(int id = 1)
        {
            IEnumerable<Customer> filteredCustomers = GetCustomers().Where(c => c.Id == id);
            return filteredCustomers.Any() ? View(filteredCustomers.First()) : NotFound();
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new() { Id = 1, Name = "John McCarther" },
                new() { Id = 2, Name = "Margaret Smith" }
            };
        }
    }
}
