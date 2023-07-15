using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Entity;

namespace Portfolio.Data
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
    }
}
