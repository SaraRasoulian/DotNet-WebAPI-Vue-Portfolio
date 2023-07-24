using Domain.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PortfolioDbContext _context;
        private readonly DbSet<T> table;
        public GenericRepository(PortfolioDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public T Add(T obj)
        {
            var result = table.Add(obj);
            return result.Entity;
        }
        public T Update(T obj)
        {
            var result = table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return result.Entity;
        }
        public void Delete(T obj)
        {
            table.Remove(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
