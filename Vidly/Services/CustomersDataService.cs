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

        public async Task AddItemAsync(Customer item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
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

        public async Task UpdateItemAsync(Customer newCustomerData)
        {
            Customer customerToUpdate = await _context.Customers.SingleAsync(c => c.Id == newCustomerData.Id);

            customerToUpdate.Name = newCustomerData.Name;
            customerToUpdate.BirthDate = newCustomerData.BirthDate;
            customerToUpdate.IsSubscribedToNewsletter = newCustomerData.IsSubscribedToNewsletter;
            customerToUpdate.MembershipTypeId = newCustomerData.MembershipTypeId;

            await _context.SaveChangesAsync();
        }
    }
}
