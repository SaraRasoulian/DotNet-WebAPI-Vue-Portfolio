using Domain.Common;

namespace Domain.Entities
{
    public class Profile : EntityBase
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Headline { get; set; }

        public string? About { get; set; }

        public string? Photo { get; set; }
    }
}
