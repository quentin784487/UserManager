﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UserManager.Service.Contracts;
using UserManager.API.Models.User;
using UserManager.Core.Domain.Entities;

namespace UserManager.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {            
            var users = await userService.GetAllAsync();
            var mappedUsers = mapper.Map<IEnumerable<UserViewModel>>(users);
            return Ok(mappedUsers);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetByIdAsync(id);
            var mappedUser = mapper.Map<UserViewModel>(user);
            return Ok(mappedUser);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel model)
        {
            var user = mapper.Map<UserViewModel, User>(model);
            userService.Create(user);
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UserViewModel model)
        {
            var user = mapper.Map<UserViewModel, User>(model);
            userService.Update(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return Ok();
        }
    }
}
