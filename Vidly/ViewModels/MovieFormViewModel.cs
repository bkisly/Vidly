using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; } = null!;
        public IEnumerable<Genre> Genres { get; set; } = null!;
    }
}
