using Bogus;
using UserManager.Infrastructure.Entities;

namespace UserManager.Tests.Repositories
{
    public class MockUserRepository
    {
        private readonly IQueryable<User> users;

        public MockUserRepository()
        {
            var user = new Faker<User>()
                .RuleFor(x => x.Id, y => 777)
                .RuleFor(x => x.Firstname, y => y.Person.FirstName)
                .RuleFor(x => x.Lastname, y => y.Person.LastName)
                .RuleFor(x => x.Email, y => y.Person.Email)
                .RuleFor(x => x.Username, y => y.Person.UserName)
                .RuleFor(x => x.Password, y => y.Random.Guid().ToString())
                .RuleFor(x => x.IsActive, true)
                .RuleFor(x => x.CreatedBy, y => y.Person.UserName)
                .RuleFor(x => x.CreatedDate, y => DateTime.Now)
                .RuleFor(x => x.ModifiedBy, y => y.Person.UserName)
                .RuleFor(x => x.ModifiedDate, y => DateTime.Now);

            users = user.Generate(1).ToList().AsQueryable();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(users.ToList());
        }

        public async Task<User> GetById(int id)
        {
            return await Task.FromResult(users.Where(x => x.Id == id).First());
        }
    }
}