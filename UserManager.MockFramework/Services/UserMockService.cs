using AutoMapper;
using Bogus;
using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;
using UserManager.MockFramework.Services.Contracts;

namespace UserManager.MockFramework.Services
{
    public class UserMockService : IUserMockService
    {
        private readonly IMapper _mapper;

        public UserMockService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllAsync()
        {
            var dataFaker = new Faker<UserCore>()
                 .RuleForType(typeof(string), f => f.Random.Word())
                 .RuleForType(typeof(int), f => f.Random.Number(10, 100))
                 .RuleForType(typeof(DateTime), f => f.Date.Past(5))
                 .RuleFor(x => x.Email, f => f.Internet.Email());

            var users = dataFaker.Generate(100).ToArray();
            var mappedUsers = _mapper.Map<IEnumerable<User>>(users);
            return mappedUsers;
        }
    }
}
