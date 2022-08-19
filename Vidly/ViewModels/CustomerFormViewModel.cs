using Vidly.Models;
using Vidly.Models.DataTransferObjects;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerDto Customer { get; set; } = new();
        public IEnumerable<MembershipType> MembershipTypes { get; set; } = null!;
    }
}
