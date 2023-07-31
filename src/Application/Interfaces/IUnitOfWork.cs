namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEducation2Repository Education2 { get; }
        Task<int> CommitAsync();
    }
}
