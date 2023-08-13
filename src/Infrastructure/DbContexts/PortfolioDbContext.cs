using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DbContexts
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
