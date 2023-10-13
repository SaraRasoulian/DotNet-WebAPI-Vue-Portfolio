using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ProfileDto
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Headline { get; set; }

        [Required]
        public string About { get; set; }

        public string? Photo { get; set; }
    }
}
