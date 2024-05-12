using Domain.Common;

namespace Domain.Entities
{
    public class Message : EntityBase
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }
    }
}
