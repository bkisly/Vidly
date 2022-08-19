using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Vidly.Models;

namespace Vidly.Models.DataTransferObjects
{
    public class CustomerDto : IDataTransferObject<Customer>
    {
        public int Id { get; set; }
        [StringLength(255)] public string Name { get; set; } = string.Empty;
        [Display(Name = "Date of birth"), AgeValidationForMembership] public DateTime? BirthDate { get; set; }
        [Display(Name = "Subscribed to newsletter?")] public bool IsSubscribedToNewsletter { get; set; }
        [Required(ErrorMessage = "Membership type is required."), Display(Name = "Membership type")] public byte? MembershipTypeId { get; set; }

        public Customer ConvertToModel()
        {
            return new Customer
            {
                Id = Id,
                Name = Name,
                BirthDate = BirthDate,
                IsSubscribedToNewsletter = IsSubscribedToNewsletter,
                MembershipTypeId = MembershipTypeId ?? 0
            };
        }

        public static CustomerDto ConvertToDto(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                MembershipTypeId = customer.MembershipTypeId,
            };
        }
    }
}
