using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.DbContexts
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SEOSettings> SEOSettings { get; set; }

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
    }
}
