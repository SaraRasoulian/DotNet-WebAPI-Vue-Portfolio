using Infrastructure.DbContexts;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.UoW;

public sealed class UnitOfWork : IUnitOfWork
{
    public IProfileRepository Profile { get; private set; }
    public IEducationRepository Education { get; private set; }
    public IExperienceRepository Experience { get; private set; }
    public IMessageRepository Message { get; private set; }
    public ISocialLinkRepository SocialLink { get; private set; }
    public IUserRepository User { get; private set; }

    private readonly PortfolioDbContext _dbContext;
    public UnitOfWork(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
        Profile = new ProfileRepository(_dbContext);
        Education = new EducationRepository(_dbContext);
        Experience = new ExperienceRepository(_dbContext);
        Message = new MessageRepository(_dbContext);
        SocialLink = new SocialLinkRepository(_dbContext);
        User = new UserRepository(_dbContext);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.DisposeAsync();
    }
}
