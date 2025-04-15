using RepositoryCleanArchitecture.Domain.Interfaces.IUnitOfWork;
using RepositoryCleanArchitecture.Infra.Data.Context;

namespace RepositoryCleanArchitecture.Infra.Data.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
