using Domain.Common;

namespace Domain.Entities;

public class SocialLink : EntityBase
{
    public string Name { get; set; } = null!;

    public string URL { get; set; } = null!;

    public string? Icon { get; set; }
}