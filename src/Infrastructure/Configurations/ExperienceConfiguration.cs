using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.Property(t => t.CompanyName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.StartYear)
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(t => t.EndYear)
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(t => t.Website)
            .HasMaxLength(255);
    }
}
