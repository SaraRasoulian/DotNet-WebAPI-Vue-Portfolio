using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Experience : EntityBase
    {       
        [MaxLength(50)]
        public required string CompanyName { get; set; }        

        [MaxLength(25)]
        public required string StartYear { get; set; }

        [MaxLength(25)]
        public required string EndYear { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }

        [MaxLength(255)]
        public string Website { get; set; } = string.Empty;
    }
}
