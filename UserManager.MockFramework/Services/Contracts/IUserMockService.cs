using UserManager.Infrastructure.Entities;

namespace UserManager.MockFramework.Services.Contracts
{
    public interface IUserMockService
    {
        IEnumerable<User> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
