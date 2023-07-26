using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class SEOSettings : EntityBase
    {
        [MaxLength(100)]
        public required string WebSiteTitle { get; set; }

        [MaxLength(250)]
        public string MetaAuthor { get; set; } = string.Empty;

        [MaxLength(250)]
        public string MetaDescription { get; set; } = string.Empty;

        [MaxLength(250)]
        public string MetaKeywords { get; set; } = string.Empty;

        public byte[]? Favicon { get; set; }
    }
}
