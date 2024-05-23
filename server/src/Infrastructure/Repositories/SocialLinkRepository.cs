using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SocialLinkRepository : ISocialLinkRepository
{
    private readonly PortfolioDbContext _dbContext;
    public SocialLinkRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SocialLink>> GetAll()
    {
        return await _dbContext.SocialLinks.ToListAsync();
    }

    public async Task<SocialLink?> GetById(Guid id)
    {
        return await _dbContext.SocialLinks.AsNoTracking().FirstOrDefaultAsync(c=>c.Id == id);
    }

    public async Task<SocialLink> Add(SocialLink model)
    {
        var result = await _dbContext.SocialLinks.AddAsync(model);
        return result.Entity;
    }

    public void Update(SocialLink model)
    {
        _dbContext.SocialLinks.Update(model);
    }

    public void Delete(SocialLink model)
    {
        _dbContext.SocialLinks.Remove(model);
    }
}
