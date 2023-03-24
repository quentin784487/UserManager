using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManager.API.Controllers;
using UserManager.Service.Contracts;
using UserManager.Infrastructure.Entities;
using UserManager.API.Models.User;
using UserManager.Tests.Repositories;

namespace UserManager.Tests;

public class UserTests : TestsBase
{
    private readonly MockUserRepository mockRepository;

    public UserTests()
    {
        mockRepository = new MockUserRepository();
    }

    [Fact]
    public async void Get_WhenCalled_GetAll_ReturnsOkResult()
    {
        // Arrange
        var mockUsers = mockRepository.GetAll();

        // Act
        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetAll()).Returns(mockUsers);

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel> (); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = await userController.GetAll();

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public async void Get_WhenCalled_GetById_ReturnsOkResult()
    {
        // Arrange
        var mockUser = mockRepository.GetById(1);

        // Act
        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetById(It.Is<long>(i => i == 1))).Returns(mockUser);
        
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = await userController.Get(1);

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public async void Get_PropertiesEqual_GetById_ReturnsOkResult()
    {
        // Arrange
        var mockUser = mockRepository.GetById(1);

        // Act
        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetById(It.Is<long>(i => i == 1))).Returns(mockUser);

        var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); });

        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = await userController.Get(1);

        // Assert          
        Assert.NotNull(okResult);

        UserViewModel? actualUser = (okResult as OkObjectResult).Value as UserViewModel;

        Assert.NotNull(mockUser);
        Assert.NotNull(actualUser);

        if (actualUser != null)
        {
            //Implementing reflection in base method to reduce code and save time.
            AssertEqual(mockUser, actualUser);
        }
    }
}