using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DbContexts
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sara",
                    LastName = "Rasoulian",
                    Email = "example@gmail.com",
                    Headline = "Lorem ipsum",
                    About = "Lorem ipsum is a placeholder text.",
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Password = "123456",
                    Email = "example@gmail.com"
                }
                );

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = Guid.NewGuid(),
                    CompanyName = "Test",
                    StartYear = "2020",
                    EndYear = "2022",
                    Description = "Lorem ipsum is a placeholder text."
                }
                );

            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    Id = Guid.NewGuid(),
                    Degree = "Bachelor's degree",
                    FieldOfStudy = "Software Engineering",
                    School = "Test University",
                    StartYear = "2016",
                    EndYear = "2020",
                    Description = "Lorem ipsum is a placeholder text."
                }
                );

            modelBuilder.Entity<SocialLink>().HasData(
                new SocialLink
                {
                    Id = Guid.NewGuid(),
                    Name = "Github",
                    URL = "https://github.com/SaraRasoulian",
                }
                );
        }
    }
}
