using AutoMapper;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Infrastructure.Entities;
using UserManager.Service.Contracts;
using UserManager.Core.Domain.Entities;

namespace UserManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserPort userPort;
        private readonly IMapper _mapper;

        public UserService(IUserPort userPort, IMapper mapper)
        {
            this.userPort = userPort;
            _mapper = mapper;   
        }

        public void Create(User user)
        {
            var mappedUser = _mapper.Map<UserCore>(user);
            userPort.CreateUser(mappedUser);
        }

        public void Update(User user)
        {
            var mappedUser = _mapper.Map<UserCore>(user);
            userPort.UpdateUser(mappedUser);
        }

        public void Delete(int id)
        {
            userPort.DeleteUser(id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = userPort.GetAllUsers();
            var mappedUsers = _mapper.Map<IEnumerable<User>>(users);
            return mappedUsers;
        }

        public User? GetById(long id)
        {
            var user = userPort.GetUserById(id);
            var mappedUser = _mapper.Map<User>(user);
            return mappedUser;
        }
    }
}
