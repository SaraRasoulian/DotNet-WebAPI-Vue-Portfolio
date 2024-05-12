using Domain.Common;

namespace Domain.Entities
{
    public class Profile : EntityBase
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Headline { get; set; } = null!;

        public string About { get; set; } = null!;

        public string? Photo { get; set; }
    }
}
