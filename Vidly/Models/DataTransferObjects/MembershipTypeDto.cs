namespace Vidly.Models.DataTransferObjects
{
    public class MembershipTypeDto : IDataTransferObject<MembershipType>
    {
        public byte Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public MembershipType ConvertToModel()
        {
            return new()
            {
                Id = Id,
                Name = Name,
            };
        }

        public static MembershipTypeDto ConvertToDto(MembershipType membershipType)
        {
            return new()
            {
                Id = membershipType.Id,
                Name = membershipType.Name,
            };
        }
    }
}
