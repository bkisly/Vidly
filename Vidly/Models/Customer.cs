using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)] public string Name { get; set; } = string.Empty;
        [AgeValidationForMembership] public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } = null!;
        public byte MembershipTypeId { get; set; }
    }
}
