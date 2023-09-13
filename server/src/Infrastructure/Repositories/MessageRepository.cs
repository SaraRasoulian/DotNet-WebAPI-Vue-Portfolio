using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly PortfolioDbContext _dbContext;
        public MessageRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _dbContext.Messages.OrderByDescending(c => c.SentAt).ToListAsync();
        }

        public async Task<Message?> GetById(Guid id)
        {
            return await _dbContext.Messages.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Message> Add(Message model)
        {
            var result = await _dbContext.Messages.AddAsync(model);
            return result.Entity;
        }

        public void Delete(Message model)
        {
            _dbContext.Messages.Remove(model);
        }
    }
}
