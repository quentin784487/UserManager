using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;

namespace UserManager.Infrastructure.Repositories.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> AuthenticateUser(string username, string password);
    }
}
