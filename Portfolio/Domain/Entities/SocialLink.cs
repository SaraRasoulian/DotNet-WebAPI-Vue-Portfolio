using Domain.Common;

namespace Domain.Entities
{
    public class SocialLink : EntityBase
    {
        public string? Name { get; set; }

        public string? URL { get; set; }

        public byte[]? Icon { get; set; }
    }
}
