
using Microsoft.EntityFrameworkCore;
using UserManager.Infrastructure.Entities;
using UserManager.Infrastructure.Persistence;
using UserManager.Infrastructure.Repositories.Contracts;

namespace UserManager.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserManagerDbContext context)
            : base(context)
        {
        }

        public UserManagerDbContext? UsersManagerDbContext
        {
            get { return Context as UserManagerDbContext; }
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            return await _dbSet.Where(x => x.Username == username && x.Password == password).AnyAsync();
        }
    }
}
