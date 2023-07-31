using Domain.Common;

namespace Domain.Entities
{
    public class Experience : EntityBase
    {
        public string? CompanyName { get; set; }

        public string? StartYear { get; set; }

        public string? EndYear { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; } = string.Empty;
    }
}
