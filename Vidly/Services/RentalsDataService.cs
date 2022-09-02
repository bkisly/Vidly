﻿using Vidly.Models;
using Vidly.Data;

namespace Vidly.Services
{
    public class RentalsDataService : IModifiableDataService<Rental>
    {
        private readonly ApplicationDbContext _context;

        public RentalsDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(Rental item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rental?> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rental[]> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(int id, Rental newItemData)
        {
            throw new NotImplementedException();
        }
    }
}
