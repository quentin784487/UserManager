using UserManager.Infrastructure.Repositories;
using UserManager.Infrastructure.Repositories.Contracts;

namespace UserManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly UserManagerDbContext _context;
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(UserManagerDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
