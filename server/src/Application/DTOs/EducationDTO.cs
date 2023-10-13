using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class EducationDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string FieldOfStudy { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string StartYear { get; set; }

        [Required]
        public required string EndYear { get; set; }

        public string? Description { get; set; }
    }
}
