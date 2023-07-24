using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SocialLink : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(2000)]
        public required string URL { get; set; }

        public byte[]? Icon { get; set; }
    }
}
