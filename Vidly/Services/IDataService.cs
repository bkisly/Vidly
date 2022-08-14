using Vidly.Models;

namespace Vidly.Services
{
    public interface IDataService<T>
    {
        public Task<T[]> GetItemsAsync();
        public Task<T?> GetItemByIdAsync(int id);
    }

    public interface IModifyableDataService<T> : IDataService<T>
    {
        public Task AddItemAsync(T item);
    }

    public interface ICustomersDataService : IModifyableDataService<Customer>
    {
        public Task<MembershipType[]> GetMembershipTypesAsync();
    }
}
