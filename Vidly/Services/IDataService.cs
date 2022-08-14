using Vidly.Models;

namespace Vidly.Services
{
    public interface IDataService<T>
    {
        public Task<T[]> GetItemsAsync();
        public Task<T?> GetItemByIdAsync(int id);
    }

    public interface ICustomersDataService : IDataService<Customer>
    {
        public Task<MembershipType[]> GetMembershipTypesAsync();
    }
}
