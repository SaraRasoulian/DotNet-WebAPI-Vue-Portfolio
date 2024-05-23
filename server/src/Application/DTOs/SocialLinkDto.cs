namespace Application.DTOs;

public record SocialLinkDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string URL { get; set; } = null!;

    public string? Icon { get; set; }
}
