using AutoMapper;
using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Outgoing;
using UserManager.Infrastructure.Entities;
using UserManager.Infrastructure.Persistence;

namespace UserManager.Infrastructure.Adapters
{
    public class UserDatabaseAdapter : IUserDatabasePort
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserDatabaseAdapter(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void CreateUser(UserCore user)
        {
            var mappedUser = _mapper.Map<User>(user);
            _unitOfWork.UserRepository.Add(mappedUser);
            await _unitOfWork.CompleteAsync();
        }

        public async void UpdateUser(UserCore user)
        {
            var mappedUser = _mapper.Map<User>(user);
            _unitOfWork.UserRepository.Update(mappedUser);
            await _unitOfWork.CompleteAsync();
        }

        public async void DeleteUser(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            if (user != null)
            {
                var mappedUser = _mapper.Map<User>(user);
                _unitOfWork.UserRepository.Remove(mappedUser);
                await _unitOfWork.CompleteAsync();
            }                
        }

        public async Task<IEnumerable<UserCore>> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            var mappedUsers = _mapper.Map<IEnumerable<UserCore>>(users);
            return mappedUsers;
        }

        public async Task<UserCore?> GetUserById(long id)
        {          
            var users = await _unitOfWork.UserRepository.GetById(id);
            var mappedUsers = _mapper.Map<UserCore>(users);
            return mappedUsers;
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            return await _unitOfWork.UserRepository.AuthenticateUser(username, password);
        }
    }
}
