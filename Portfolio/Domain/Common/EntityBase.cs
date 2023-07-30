using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
