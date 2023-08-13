using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEducationRepository Education { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}