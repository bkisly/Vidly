using Vidly.Models;
using Vidly.Data;

namespace Vidly.Services
{
    public class CustomersDataService : ICustomerDataService
    {
        private readonly ApplicationDbContext _context;

        public CustomersDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(_context.Customers.FirstOrDefault(c => c.Id == id));
        }

        public Task<Customer[]> GetItemsAsync()
        {
            return Task.FromResult(_context.Customers.ToArray());
        }
    }
}
