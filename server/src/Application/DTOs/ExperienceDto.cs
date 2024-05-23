namespace Application.DTOs;

public record ExperienceDto
{
    public Guid Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string StartYear { get; set; } = null!;

    public string EndYear { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; } = string.Empty;
}