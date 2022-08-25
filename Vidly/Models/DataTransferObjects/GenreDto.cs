namespace Vidly.Models.DataTransferObjects
{
    public class GenreDto : IDataTransferObject<Genre>
    {
        public byte Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Genre ConvertToModel() => new() { Id = Id, Name = Name };
        public static GenreDto ConvertToDto(Genre genre) => new() { Id = genre.Id, Name = genre.Name };
    }
}
