using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserManager.API.Controllers;
using UserManager.API.Models.User;
using UserManager.Core.Domain.Entities;
using UserManager.Infrastructure.Entities;
using UserManager.Service.Contracts;

namespace UserManager.Tests;

public class UserTests
{
    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        //Arrange
        int userId = new Random().Next();

        var user = new User { Id = userId, Firstname = "firstname", Lastname = "lastname", Email = "email", Username = "username", Password = "password", IsActive = true, CreatedBy = "createdby", CreatedDate = DateTime.Now, ModifiedBy = "modifiedby", ModifiedDate = DateTime.Now };

        var mockUserService = new Mock<IUserService>();

        mockUserService.Setup(x => x.GetByIdAsync(It.Is<long>(i => i == userId))).Returns(user);
        
        var config = new MapperConfiguration(cfg => {  cfg.CreateMap<User, UserViewModel> (); });

        // Act
        var userController = new UserController(new Mapper(config), mockUserService.Object);

        var okResult = userController.Get(userId);

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }
}