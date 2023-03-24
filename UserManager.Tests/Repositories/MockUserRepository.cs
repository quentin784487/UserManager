using UserManager.Infrastructure.Entities;

namespace UserManager.Tests.Repositories
{
    public class MockUserRepository
    {
        private readonly IQueryable<User> mockUsers;

        public MockUserRepository()
        {
            mockUsers = new List<User>()
            {
                new User() { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now }            
            }.AsQueryable();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(mockUsers.ToList());
        }

        public async Task<User> GetById(int id)
        {
            return await Task.FromResult(mockUsers.Where(x => x.Id == id).First());
        }

        public async Task<bool> Autehnticate(string username, string password)
        {
            return await Task.FromResult(mockUsers.Where(x=>x.Username == username && x.Password == password).Any());
        }
    }
}