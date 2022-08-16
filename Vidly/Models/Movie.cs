using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; } = string.Empty;
        [Required, Display(Name = "Release date")] public DateTime ReleaseDate { get; set; }
        [Required] public DateTime DateAdded { get; set; }
        [Required, Display(Name = "Number in stock")] public short NumberInStock { get; set; }

        public Genre Genre { get; set; } = null!;
        [Required, Display(Name = "Genre")] public byte GenreId { get; set; }
    }
}
