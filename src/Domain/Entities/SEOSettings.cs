using Domain.Common;

namespace Domain.Entities
{
    public class SEOSettings : EntityBase
    {
        public string? WebSiteTitle { get; set; }

        public string? MetaAuthor { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public byte[]? Favicon { get; set; }
    }
}
