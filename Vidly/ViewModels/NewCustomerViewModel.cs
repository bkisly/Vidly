using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public Customer Customer { get; set; } = null!;
        public IEnumerable<MembershipType> MembershipTypes { get; set; } = null!;
    }
}
