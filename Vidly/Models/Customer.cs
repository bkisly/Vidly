using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)] public string Name { get; set; } = string.Empty;
        [Display(Name = "Date of birth"), AgeValidationForMembership] public DateTime? BirthDate { get; set; }
        [Display(Name = "Subscribed to newsletter?")] public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType? MembershipType { get; set; }
        [Required(ErrorMessage = "Membership type is required."), Display(Name = "Membership type")] public byte? MembershipTypeId { get; set; }
    }
}
