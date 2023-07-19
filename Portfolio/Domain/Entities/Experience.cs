using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Experience : ObjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string CompanyName { get; set; }        

        [MaxLength(25)]
        public required string StartYear { get; set; }

        [MaxLength(25)]
        public required string EndYear { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }

        [MaxLength(255)]
        public string? Website { get; set; }
    }
}
