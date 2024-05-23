namespace Application.DTOs;

public record EducationDto
{
    public Guid Id { get; set; }

    public string Degree { get; set; } = null!;

    public string FieldOfStudy { get; set; } = null!;

    public string StartYear { get; set; } = null!;

    public string EndYear { get; set; } = null!;

    public string? School { get; set; }

    public string? Description { get; set; }
}
