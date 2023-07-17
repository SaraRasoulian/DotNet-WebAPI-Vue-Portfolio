using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class SEOSettings : ObjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
