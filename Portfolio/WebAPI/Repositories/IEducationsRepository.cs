using Domain.Entities;

namespace WebAPI.Repositories
{
    public interface IEducationsRepository
    {
        Task<IEnumerable<Education>> Get();
        Task<Education?> GetById(Guid id);
        Task<Education?> Add(Education model);
        Task<Education?> UpdateById(Guid id ,Education model);
        Task<Education?> DeleteById(Guid id);
    }
}
