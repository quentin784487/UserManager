using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Core.Domain.Ports.Outgoing;

namespace UserManager.Core.Domain.Ports.Adapters
{
    public class UserAdapter : IUserPort
    {
        private IUserDatabasePort database;

        public UserAdapter(IUserDatabasePort database)
        {
            this.database = database;
        }

        public void CreateUser(User user)
        {
            database.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            database.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            database.DeleteUser(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await database.GetAllUsers();
        }

        public async Task<User?> GetUserById(long id)
        {
            return await database.GetUserById(id);
        }        
    }
}
