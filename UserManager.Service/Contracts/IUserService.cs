using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;

namespace UserManager.Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(long id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
