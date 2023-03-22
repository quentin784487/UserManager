using UserManager.Core.Domain.Entities;

namespace UserManager.MockFramework.Services.Contracts
{
    public interface IUserMockService
    {
        IEnumerable<CoreUser> GetAllAsync();
    }
}
