using Microsoft.AspNetCore.Mvc;
using UserManager.MockFramework.Services;
using UserManager.MockFramework.Services.Contracts;

namespace UserManager.UnitTests
{
    public class UsersTest : IClassFixture<UserMockService>
    {
        private readonly IUserMockService _userService;

        public UsersTest(IUserMockService userService)
        {
            _userService = userService;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _userService.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
