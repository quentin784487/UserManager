using UserManager.Core.Domain.Entities;

namespace UserManager.Core.Domain.Ports.Incoming
{
    public interface IUserPort
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(long id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
