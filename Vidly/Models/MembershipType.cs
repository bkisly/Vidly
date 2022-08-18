using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }

    public enum MembershipTypeCode : byte
    {
        Unknown,
        PayAsYouGo,
        Monthly,
        Quarterly,
        Annually
    }
}
