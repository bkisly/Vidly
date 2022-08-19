using System.ComponentModel.DataAnnotations;
using Vidly.Models.DataTransferObjects;

namespace Vidly.Models
{
    public class AgeValidationForMembershipAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CustomerDto customer = (CustomerDto)validationContext.ObjectInstance;

            if (customer is { MembershipTypeId: null or (byte?)MembershipTypeCode.Unknown or (byte?)MembershipTypeCode.PayAsYouGo })
                return ValidationResult.Success;

            if (customer.BirthDate is null) return new ValidationResult("Date of Birth field is required when signing up for a membership.");
            if (customer.BirthDate.Value.AddYears(18) <= DateTime.Now) return ValidationResult.Success;
            else return new ValidationResult("Customer must be at least 18 years old in order to sign up for a membership.");
        }
    }
}
