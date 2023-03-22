using Bogus;
using UserManager.Core.Domain.Entities;
using UserManager.MockFramework.Services.Contracts;

namespace UserManager.MockFramework.Services
{
    public class UserMockService : IUserMockService
    {
        public IEnumerable<User> GetAllAsync()
        {
            var dataFaker = new Faker<User>()
                 .RuleForType(typeof(string), f => f.Random.Word())
                 .RuleForType(typeof(int), f => f.Random.Number(10, 100))
                 .RuleForType(typeof(DateTime), f => f.Date.Past(5))
                 .RuleFor(x => x.Email, f => f.Internet.Email());

            var users = dataFaker.Generate(100).ToArray();
            return users;
        }
    }
}
