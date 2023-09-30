using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string? SentAt { get; set; }

        public string? TimeAgo { get; set; }
    }
}
