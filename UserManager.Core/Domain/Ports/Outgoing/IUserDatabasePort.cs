using UserManager.Core.Domain.Entities;

namespace UserManager.Core.Domain.Ports.Outgoing
{
    public interface IUserDatabasePort
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(long id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
