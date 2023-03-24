using UserManager.Core.Domain.Entities;

namespace UserManager.Core.Domain.Ports.Incoming
{
    public interface IUserPort
    {
        Task<IEnumerable<UserCore>> GetAllUsers();
        Task<UserCore?> GetUserById(long id);
        void CreateUser(UserCore user);
        void UpdateUser(UserCore user);
        void DeleteUser(int id);
        Task<bool> AuthenticateUser(string username, string password);
    }
}
