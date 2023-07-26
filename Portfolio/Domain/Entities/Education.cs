using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Education : EntityBase
    {
        [MaxLength(50)]
        public required string Degree { get; set; }

        [MaxLength(250)]
        public required string FieldOfStudy { get; set; }

        [MaxLength(250)]
        public required string School { get; set; }        

        [MaxLength(25)]
        public required string StartYear { get; set; }

        [MaxLength(25)]
        public required string EndYear { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
