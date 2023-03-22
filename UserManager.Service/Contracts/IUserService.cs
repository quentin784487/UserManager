using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;

namespace UserManager.Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
