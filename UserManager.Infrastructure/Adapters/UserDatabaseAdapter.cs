using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Outgoing;
using UserManager.Infrastructure.Persistence;

namespace UserManager.Infrastructure.Adapters
{
    public class UserDatabaseAdapter : IUserDatabasePort
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDatabaseAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async void CreateUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CompleteAsync();
        }

        public async void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async void DeleteUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user != null)
            {
                _unitOfWork.UserRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }                
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User?> GetUserById(long id)
        {           
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }        
    }
}
