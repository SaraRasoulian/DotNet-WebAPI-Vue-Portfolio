using System.Collections.Generic;

namespace WebAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
        void Save();
    }
}
