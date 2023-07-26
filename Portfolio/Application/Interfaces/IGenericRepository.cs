using System.Collections.Generic;

namespace WebAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Add(T obj);
        T Update(T obj);
        void Delete(T obj);
        void Save();
    }
}
