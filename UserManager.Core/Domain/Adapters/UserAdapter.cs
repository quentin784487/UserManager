using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Core.Domain.Ports.Outgoing;

namespace UserManager.Core.Domain.Ports.Adapters
{
    public class UserAdapter : IUserPort
    {
        private IUserDatabasePort userDatabasePort;

        public UserAdapter(IUserDatabasePort userDatabasePort)
        {
            this.userDatabasePort = userDatabasePort;
        }

        public void CreateUser(UserCore user)
        {
            userDatabasePort.CreateUser(user);
        }

        public void UpdateUser(UserCore user)
        {
            userDatabasePort.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userDatabasePort.DeleteUser(id);
        }

        public async Task<IEnumerable<UserCore>> GetAllUsers()
        {
            return await userDatabasePort.GetAllUsers();
        }

        public async Task<UserCore?> GetUserById(long id)
        {
            return await userDatabasePort.GetUserById(id);
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            return await userDatabasePort.AuthenticateUser(username, password);
        }
    }
}
