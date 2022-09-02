namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        public Customer Customer { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
