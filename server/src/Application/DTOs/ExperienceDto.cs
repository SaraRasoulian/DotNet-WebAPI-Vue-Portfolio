using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ExperienceDto
    {
        public Guid Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string StartYear { get; set; }

        [Required]
        public string EndYear { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; } = string.Empty;
    }
}
