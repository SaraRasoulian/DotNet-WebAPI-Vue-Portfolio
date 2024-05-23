using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly PortfolioDbContext _dbContext;
    public ExperienceRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Experience>> GetAll()
    {
        return await _dbContext.Experiences.OrderByDescending(c => c.StartYear).ThenByDescending(c => c.EndYear).ToListAsync();
    }

    public async Task<Experience?> GetById(Guid id)
    {
        return await _dbContext.Experiences.AsNoTracking().FirstOrDefaultAsync(c=>c.Id == id);
    }

    public async Task<Experience> Add(Experience model)
    {
        var result = await _dbContext.Experiences.AddAsync(model);
        return result.Entity;
    }

    public void Update(Experience model)
    {
        _dbContext.Experiences.Update(model);
    }

    public void Delete(Experience model)
    {
        _dbContext.Experiences.Remove(model);
    }
}
