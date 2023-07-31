using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(t => t.Headline)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.About)
            .HasMaxLength(1000)
            .IsRequired();
    }
}
