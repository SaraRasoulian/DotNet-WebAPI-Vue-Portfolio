using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entity
{
    public class SocialLink
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(2000)]
        public required string URL { get; set; }

        public byte[]? Icon { get; set; }
    }
}
