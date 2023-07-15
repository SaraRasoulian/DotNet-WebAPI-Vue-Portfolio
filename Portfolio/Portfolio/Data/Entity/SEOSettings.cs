using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entity
{
    public class SEOSettings
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public required string WebSiteTitle { get; set; }

        [MaxLength(250)]
        public string? MetaAuthor { get; set; }

        [MaxLength(250)]
        public string? MetaDescription { get; set; }

        [MaxLength(250)]
        public string? MetaKeywords { get; set; }

        public byte[]? Favicon { get; set; }
    }
}
