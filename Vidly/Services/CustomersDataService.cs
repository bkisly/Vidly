using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Services
{
    public class CustomersDataService : ICustomersDataService
    {
        private readonly ApplicationDbContext _context;

        public CustomersDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetItemByIdAsync(int id)
        {
            return await _context.Customers.Include(c => c.MembershipType).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer[]> GetItemsAsync()
        {
            return await _context.Customers.Include(c => c.MembershipType).ToArrayAsync();
        }

        public async Task<MembershipType[]> GetMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToArrayAsync();
        }
    }
}
