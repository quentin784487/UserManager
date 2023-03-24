using Microsoft.EntityFrameworkCore;
using UserManager.Infrastructure.Entities;

namespace UserManager.Tests.Repositories
{
    public class MockUserRepository
    {
        private readonly IQueryable<User> users;

        public MockUserRepository()
        {
            users = new List<User>() {
                new User() { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
                new User() { Id = 2, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
                new User() { Id = 3, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
                new User() { Id = 4, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
                new User() { Id = 5, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now }
            }.AsQueryable();
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