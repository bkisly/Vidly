using Vidly.Models;

namespace Vidly.Services
{
    public interface IDataService<T>
    {
        public Task<T[]> GetItemsAsync();
    }
    
    public interface ICustomerDataService : IDataService<Customer>
    {
        public Task<Customer?> GetCustomerByIdAsync(int id);
    }
}
