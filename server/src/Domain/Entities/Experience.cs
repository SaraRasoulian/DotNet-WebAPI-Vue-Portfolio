using Domain.Common;

namespace Domain.Entities;

public class Experience : EntityBase
{
    public string CompanyName { get; set; } = null!;

    public string StartYear { get; set; } = null!;
     
    public string EndYear { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Website { get; set; }
}