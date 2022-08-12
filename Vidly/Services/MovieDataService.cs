using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Services
{
    public class MovieDataService : IDataService<Movie>
    {
        private readonly ApplicationDbContext _context;

        public MovieDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie?> GetItemByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie[]> GetItemsAsync()
        {
            return await _context.Movies.Include(m => m.Genre).ToArrayAsync();
        }
    }
}
