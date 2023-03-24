using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;

namespace UserManager.Service.Contracts
{
    public interface IUserService
    {        
        void Create(User user);
        void Update(User user);
        void Delete(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(long id);
    }
}
