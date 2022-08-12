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
    }
}
