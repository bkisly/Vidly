﻿using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(255)] public string Name { get; set; } = string.Empty;
        [Display(Name = "Date of birth")] public DateTime? BirthDate { get; set; }
        [Required, Display(Name = "Subscribed to newsletter?")] public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } = null!;
        [Required, Display(Name = "Membership type")] public byte MembershipTypeId { get; set; }
    }
}
