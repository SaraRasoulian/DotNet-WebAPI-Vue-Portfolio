using Application.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PortfolioDbContext _context;
        private readonly DbSet<T> table;
        protected GenericRepository(PortfolioDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        public async Task<T> Add(T obj)
        {
            var result = await table.AddAsync(obj);
            return result.Entity;
        }
        public void Update(T obj)
        {
            table.Update(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            table.Remove(obj);
        }
        //public async void Save()
        //{
        //   await _context.SaveChangesAsync();
        //}
    }
}
