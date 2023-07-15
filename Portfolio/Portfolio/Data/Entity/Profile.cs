using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Data.Entity
{
    public class Profile : ObjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
