using Vidly.Models;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Services
{
    public class MovieDataService : IMoviesDataService
    {
        private readonly ApplicationDbContext _context;

        public MovieDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(Movie item)
        {
            await _context.Movies.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            _context.Movies.Remove(await _context.Movies.SingleAsync(m => m.Id == id));
            await _context.SaveChangesAsync();
        }

        public async Task<Genre[]> GetGenresAsync()
        {
            return await _context.Genres.ToArrayAsync();
        }

        public async Task<Movie?> GetItemByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie[]> GetItemsAsync()
        {
            return await _context.Movies.Include(m => m.Genre).ToArrayAsync();
        }

        public async Task UpdateItemAsync(Movie newMovieData)
        {
            Movie movieToUpdate = _context.Movies.Single(m => m.Id == newMovieData.Id);

            movieToUpdate.Title = newMovieData.Title;
            movieToUpdate.ReleaseDate = newMovieData.ReleaseDate;
            movieToUpdate.GenreId = newMovieData.GenreId;
            movieToUpdate.NumberInStock = newMovieData.NumberInStock;

            await _context.SaveChangesAsync();
        }
    }
}
