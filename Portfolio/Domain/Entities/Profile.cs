using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Profile : EntityBase
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(320)]
        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(100)]
        public required string Headline { get; set; }

        [MaxLength(1000)]
        public required string About { get; set; }

        public byte[]? Photo { get; set; }
    }
}
