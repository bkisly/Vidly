using Vidly.Models;
using Vidly.Models.DataTransferObjects;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieDto Movie { get; set; } = new();
        public IEnumerable<Genre> Genres { get; set; } = null!;
    }
}
