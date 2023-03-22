
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

        public override void Add(User entity)
        {
            // We can override repository virtual methods in order to customize repository behavior, Template Method Pattern Code here
            base.Add(entity);
        }
    }
}
