using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entity
{
    public class Education
    {
        public Guid Id { get; set; }

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
        public required string Description { get; set; }
    }
}
