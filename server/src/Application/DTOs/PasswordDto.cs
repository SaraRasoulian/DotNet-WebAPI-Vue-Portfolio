namespace Application.DTOs;

public record PasswordDto
{
    public string currentPassword { get; set; } = null!;

    public string newPassword { get; set; } = null!;

    public string confirmNewPassword { get; set; } = null!;
}
