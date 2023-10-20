using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
