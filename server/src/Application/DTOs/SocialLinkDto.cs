using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class SocialLinkDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        public string? Icon { get; set; }
    }
}
