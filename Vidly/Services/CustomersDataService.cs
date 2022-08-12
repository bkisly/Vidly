using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;

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
            return Task.FromResult(_context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id));
        }

        public Task<Customer[]> GetItemsAsync()
        {
            return Task.FromResult(_context.Customers.Include(c => c.MembershipType).ToArray());
        }
    }
}
