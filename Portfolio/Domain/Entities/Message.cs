using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Message : EntityBase
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(320)]
        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(500)]
        public required string Content { get; set; }

        public bool IsRead { get; set; }
    }
}
