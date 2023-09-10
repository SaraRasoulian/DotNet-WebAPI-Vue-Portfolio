using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEducationRepository Education { get; }
        IProfileRepository Profile { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}