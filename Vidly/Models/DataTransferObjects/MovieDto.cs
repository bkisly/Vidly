using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DataTransferObjects
{
    public class MovieDto : IDataTransferObject<Movie>
    {
        public int Id { get; set; }
        [StringLength(255)] public string Title { get; set; } = string.Empty;
        [Required, Display(Name = "Release date")] public DateTime? ReleaseDate { get; set; }
        [Required, Display(Name = "Number in stock"), Range(1, 20)] public short? NumberInStock { get; set; }
        public GenreDto? Genre { get; set; }
        [Required, Display(Name = "Genre")] public byte? GenreId { get; set; }

        public Movie ConvertToModel()
        {
            return new Movie
            {
                Id = Id,
                Title = Title,
                ReleaseDate = ReleaseDate ?? DateTime.MinValue,
                NumberInStock = NumberInStock ?? 0,
                GenreId = GenreId ?? 0,
            };
        }

        public static MovieDto ConvertToDto(Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genre = GenreDto.ConvertToDto(movie.Genre)
            };
        }
    }
}
