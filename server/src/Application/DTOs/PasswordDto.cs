using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PasswordDto
    {
        [Required]
        public string currentPassword { get; set; }

        [Required]
        public string newPassword { get; set; }

        [Required]
        public string confirmNewPassword { get; set; }
    }
}
