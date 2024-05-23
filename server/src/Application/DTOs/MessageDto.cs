namespace Application.DTOs;

public record MessageDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsRead { get; set; }

    public string? SentAt { get; set; }

    public string? TimeAgo { get; set; }
}