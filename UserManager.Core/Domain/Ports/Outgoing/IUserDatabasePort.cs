using UserManager.Core.Domain.Entities;

namespace UserManager.Core.Domain.Ports.Outgoing
{
    public interface IUserDatabasePort
    {
        Task<IEnumerable<UserCore>> GetAllUsers();
        Task<UserCore?> GetUserById(long id);
        void CreateUser(UserCore user);
        void UpdateUser(UserCore user);
        void DeleteUser(int id);
    }
}
