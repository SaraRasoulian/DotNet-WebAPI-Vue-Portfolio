using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid LastUpdatedBy { get; set;} = Guid.Empty;
    }
}
