using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;

namespace Infrastructure.Data.DbContexts
{
    public class PortfolioDbContext : DbContext, IPortfolioDbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<Experience> Experiences => Set<Experience>()
            ;
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<SocialLink> SocialLinks => Set<SocialLink>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<SEOSettings> SEOSettings => Set<SEOSettings>();
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sara",
                    LastName = "Rasoulian",
                    Email = "Example@gmail.com",
                    Headline = "My name is Sara",
                    About = "In publishing and graphic design, Lorem ipsum is a placeholder text.",
                }
                );

            modelBuilder.Entity<SEOSettings>().HasData(
                new SEOSettings
                {
                    Id = Guid.NewGuid(),
                    WebSiteTitle = "Sara Rasoulian | Portfolio",             
                }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
