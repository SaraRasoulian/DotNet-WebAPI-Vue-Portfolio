using Domain.Common;

namespace Domain.Entities
{
    public class Message : EntityBase
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Content { get; set; }

        public bool IsRead { get; set; }
    }
}
