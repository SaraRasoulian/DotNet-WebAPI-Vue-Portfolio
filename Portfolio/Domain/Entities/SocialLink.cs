using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class SocialLink : EntityBase
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(2000)]
        public required string URL { get; set; }

        public byte[]? Icon { get; set; }
    }
}
