using Microsoft.EntityFrameworkCore;
using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Persistence;

namespace UserManager.API
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserManagerDbContext(serviceProvider.GetRequiredService<DbContextOptions<UserManagerDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;   // Data was already seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Firstname = "User#1",
                        Lastname = "Surname#1",
                        Email = "Email#1",
                        Username = "Username#1",
                        Password = "Password#1",
                        IsActive = true,
                        CreatedBy = "User#1",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "User#1",
                        ModifiedDate = DateTime.Now

                    },
                    new User
                    {
                        Id = 2,
                        Firstname = "User#2",
                        Lastname = "Surname#2",
                        Email = "Email#2",
                        Username = "Username#2",
                        Password = "Password#2",
                        IsActive = true,
                        CreatedBy = "User#2",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "User#2",
                        ModifiedDate = DateTime.Now

                    },
                    new User
                    {
                        Id = 3,
                        Firstname = "User#3",
                        Lastname = "Surname#3",
                        Email = "Email#3",
                        Username = "Username#3",
                        Password = "Password#3",
                        IsActive = true,
                        CreatedBy = "User#3",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "User#3",
                        ModifiedDate = DateTime.Now

                    },
                    new User
                    {
                        Id = 4,
                        Firstname = "User#4",
                        Lastname = "Surname#4",
                        Email = "Email#4",
                        Username = "Username#4",
                        Password = "Password#4",
                        IsActive = true,
                        CreatedBy = "User#4",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "User#4",
                        ModifiedDate = DateTime.Now

                    },
                    new User
                    {
                        Id = 5,
                        Firstname = "User#5",
                        Lastname = "Surname#5",
                        Email = "Email#5",
                        Username = "Username#5",
                        Password = "Password#5",
                        IsActive = true,
                        CreatedBy = "User#5",
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "User#5",
                        ModifiedDate = DateTime.Now

                    });
                context.SaveChanges();
            }
        }
    }
}
