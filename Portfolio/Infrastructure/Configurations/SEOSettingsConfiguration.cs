using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class SEOSettingsConfiguration : IEntityTypeConfiguration<SEOSettings>
{
    public void Configure(EntityTypeBuilder<SEOSettings> builder)
    {
        builder.Property(t => t.WebSiteTitle)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.MetaAuthor)
            .HasMaxLength(250);

        builder.Property(t => t.MetaKeywords)
            .HasMaxLength(250);

        builder.Property(t => t.MetaDescription)
            .HasMaxLength(250);
    }
}
