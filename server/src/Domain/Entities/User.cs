using Domain.Common;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }
    }
}
