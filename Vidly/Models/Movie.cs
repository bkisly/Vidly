using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Release date")] public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number in stock"), Range(1, 20)] public short NumberInStock { get; set; }

        public Genre? Genre { get; set; }
        [Display(Name = "Genre")] public byte GenreId { get; set; }
    }
}
