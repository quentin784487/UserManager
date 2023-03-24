using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManager.Infrastructure.Entities;

namespace UserManager.Infrastructure.Persistence
{
    public class UserManagerDbContext : DbContext
    {
        public virtual DbSet<User>? Users { get; set; }

        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
