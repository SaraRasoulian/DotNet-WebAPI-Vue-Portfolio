namespace Application.DTOs;

public record ProfileDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Headline { get; set; } = null!;

    public string About { get; set; } = null!;

    public string? Photo { get; set; }
}
