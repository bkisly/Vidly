using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(255)] public string DrivingLicense { get; set; } = string.Empty;
    }
}
