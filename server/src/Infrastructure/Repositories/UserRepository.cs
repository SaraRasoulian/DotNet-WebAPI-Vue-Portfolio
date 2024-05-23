using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PortfolioDbContext _dbContext;
    public UserRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> Get(string userName, string password)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(c => c.UserName.ToLower() == userName.ToLower() && c.Password == password);
    }

    public async Task<User?> GetByUserName(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(c => c.UserName.ToLower() == userName.ToLower());
    }


    public async void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
