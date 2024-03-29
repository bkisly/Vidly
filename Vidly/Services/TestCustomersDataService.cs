﻿using Vidly.Models;

namespace Vidly.Services
{
    public class TestCustomersDataService : IDataService<Customer>
    {
        public Task<Customer[]> GetItemsAsync()
        {
            return Task.FromResult(new Customer[2]
            {
                new() { Id = 1, Name = "John McCarther" },
                new() { Id = 2, Name = "Margaret Smith" }
            });
        }
        public async Task<Customer?> GetItemByIdAsync(int id)
        {
            var items = await GetItemsAsync();
            return items.FirstOrDefault(x => x.Id == id);
        }
    }
}
