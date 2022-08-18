using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; } = new();
        public IEnumerable<Genre> Genres { get; set; } = null!;
    }
}
