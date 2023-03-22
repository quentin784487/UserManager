using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Service.Contracts;

namespace UserManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserPort userPort;

        public UserService(IUserPort userPort)
        {
            this.userPort = userPort;
        }

        public void Create(User user)
        {
            userPort.CreateUser(user);
        }

        public void Update(User user)
        {
            userPort.UpdateUser(user);
        }

        public void Delete(int id)
        {
            userPort.DeleteUser(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userPort.GetAllUsers();
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            return await userPort.GetUserById(id);
        }
    }
}
