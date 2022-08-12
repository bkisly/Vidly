namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } = null!;
        public byte MembershipTypeId { get; set; }
    }
}
