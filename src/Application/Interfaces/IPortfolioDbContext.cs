using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IPortfolioDbContext
    {
        DbSet<Profile> Profiles { get; }
        DbSet<Experience> Experiences { get; }
        DbSet<Education> Educations { get; }
        DbSet<SocialLink> SocialLinks { get; }
        DbSet<Message> Messages { get; }
        DbSet<SEOSettings> SEOSettings { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Dispose();
    }
}
