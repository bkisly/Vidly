namespace Vidly.Models.DataTransferObjects
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> MovieIds { get; set; } = null!;
    }
}
