using Vidly.Models;

namespace Vidly.Services
{
    public class TestMoviesDataService : IDataService<Movie>
    {
        public Task<Movie[]> GetItemsAsync()
        {
            return Task.FromResult(new Movie[2]
            {
                new() { Id = 1, Title = "Shrek!" },
                new() { Id = 2, Title = "Wall-E" }
            });
        }

        public async Task<Movie?> GetItemByIdAsync(int id)
        {
            var items = await GetItemsAsync();
            return items.FirstOrDefault(movie => movie.Id == id);
        }
    }
}
