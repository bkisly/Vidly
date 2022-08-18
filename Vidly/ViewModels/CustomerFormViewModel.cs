using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; } = new();
        public IEnumerable<MembershipType> MembershipTypes { get; set; } = null!;
    }
}
