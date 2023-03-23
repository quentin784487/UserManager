using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManager.API.Controllers;
using UserManager.API.Models.User;
using UserManager.Infrastructure.Entities;
using UserManager.Service.Contracts;

namespace UserManager.Tests;

public class UserTests : TestsBase
{
    [Fact]
    public void Get_WhenCalled_GetAll_ReturnsOkResult()
    {
        var id = 1;
        // Arrange
        IEnumerable<User> mockUsers = new List<User>()
        {
            new User() { Id = id, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
            new User() { Id = id++, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
            new User() { Id = id++, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
            new User() { Id = id++, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now },
            new User() { Id = id++, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now }
        };

        // Act
        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetAll()).Returns((mockUsers));

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = userController.GetAll();

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void Get_WhenCalled_Get_ReturnsOkResult()
    {
        // Arrange
        int userId = new Random().Next();

        var mockUser = new User { Id = userId, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now };

        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetById(It.Is<long>(i => i == userId))).Returns(mockUser);

        // Act
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = userController.Get(userId);

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void Get_PropertyValidation_Get_ReturnsOkResult()
    {
        // Arrange
        int userId = new Random().Next();

        var mockUser = new User { Id = userId, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now };

        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetById(It.Is<long>(i => i == userId))).Returns(mockUser);

        // Act
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var actionResult = userController.Get(userId);

        // Assert          
        Assert.NotNull(actionResult);

        UserViewModel actualUser = (actionResult as OkObjectResult).Value as UserViewModel;

        Assert.NotNull(actualUser);

        if (actualUser != null)
        {
            //Implementing reflection in base method to reduce code
            AssertEqual(mockUser, actualUser);
        }
    }
}