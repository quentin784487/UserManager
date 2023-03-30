using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UserManager.Service.Contracts;
using UserManager.API.Models.User;
using UserManager.Core.Domain.Entities;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Infrastructure.Entities;

namespace UserManager.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly IMapper mapper;
        private readonly IUserPort userPort;

        public UserController(IMapper mapper, IUserPort userPort)
        {
            this.mapper = mapper;
            this.userPort = userPort;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {            
            var users = await userPort.GetAllUsers();
            var mappedUsers = mapper.Map<IEnumerable<UserViewModel>>(users);
            return Ok(mappedUsers);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userPort.GetUserById(id);
            var mappedUser = mapper.Map<UserViewModel>(user);
            return Ok(mappedUser);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel model)
        {
            var user = mapper.Map<UserViewModel, UserCore>(model);
            userPort.CreateUser(user);
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserViewModel model)
        {
            var user = mapper.Map<UserViewModel, UserCore>(model);
            userPort.UpdateUser(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            userPort.DeleteUser(id);
            return Ok();
        }

        // GET: api/<UsersController>/username/password
        [HttpGet("Users/Authenticate{username}/{password}")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            return Ok(await userPort.AuthenticateUser(username, password));
        }
    }
}
