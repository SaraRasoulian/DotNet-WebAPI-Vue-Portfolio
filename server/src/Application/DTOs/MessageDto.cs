namespace Application.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Content { get; set; }

        public bool IsRead { get; set; }

        public string? SentAt { get; set; }

        public string? TimeAgo { get; set; }
    }
}
