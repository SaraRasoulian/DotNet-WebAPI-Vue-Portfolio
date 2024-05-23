using Domain.Common;

namespace Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }
}