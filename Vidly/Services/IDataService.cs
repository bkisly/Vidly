using Vidly.Models;

namespace Vidly.Services
{
    public interface IDataService<T>
    {
        public Task<T[]> GetItemsAsync();
        public Task<T?> GetItemByIdAsync(int id);
    }

    public interface IModifiableDataService<T> : IDataService<T>
    {
        public Task AddItemAsync(T item);
        public Task UpdateItemAsync(int id, T newItemData);
        public Task DeleteItemAsync(int id);
    }

    public interface ICustomersDataService : IModifiableDataService<Customer>
    {
        public Task<MembershipType[]> GetMembershipTypesAsync();
    }

    public interface IMoviesDataService : IModifiableDataService<Movie>
    {
        public Task<Genre[]> GetGenresAsync();
    }
}
