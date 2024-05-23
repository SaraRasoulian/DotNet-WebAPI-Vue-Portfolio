namespace Application.DTOs;

public record UserLoginDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
