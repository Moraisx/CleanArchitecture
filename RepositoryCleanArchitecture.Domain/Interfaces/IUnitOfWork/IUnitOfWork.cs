namespace RepositoryCleanArchitecture.Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
