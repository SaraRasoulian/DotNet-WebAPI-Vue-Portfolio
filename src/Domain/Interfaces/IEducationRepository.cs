using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IEducationRepository : IDisposable
    {
        Task<IEnumerable<Education>> GetAll();
        Task<Education?> GetById(Guid id);
        Task Add(Education model);
        void Update(Education model);
        void Delete(Education model);
    }
}