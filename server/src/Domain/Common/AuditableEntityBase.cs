using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public abstract class AuditableEntityBase
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public Guid LastUpdatedBy { get; set; }
}