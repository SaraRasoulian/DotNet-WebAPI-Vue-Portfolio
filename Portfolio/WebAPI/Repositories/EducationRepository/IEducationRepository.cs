using Domain.Entities;

namespace WebAPI.Repositories
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAll();
        Task<Education?> GetById(Guid id);
        Task<Education?> Add(Education model);
        Task<Education?> Update(Guid id ,Education model);
        Task Delete(Education model);
    }
}
