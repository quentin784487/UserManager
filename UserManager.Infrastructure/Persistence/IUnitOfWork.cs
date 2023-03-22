using UserManager.Infrastructure.Repositories.Contracts;

namespace UserManager.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> CompleteAsync();
        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
