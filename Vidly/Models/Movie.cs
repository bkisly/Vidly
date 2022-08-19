using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1, 20)] public short NumberInStock { get; set; }

        public Genre Genre { get; set; } = null!;
        public byte GenreId { get; set; }
    }
}
