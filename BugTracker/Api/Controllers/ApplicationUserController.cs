using Application.Commands;
using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using AutoMapper;
using Domain;
using EfCommands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Hash;
using Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserCommands applicationUserCommands;
        private readonly IMapper mapper;

        public ApplicationUserController(IApplicationUserCommands applicationUserCommands, IMapper mapper)
        {
            this.applicationUserCommands = applicationUserCommands;
            this.mapper = mapper;
        }

        // GET: api/<ApplicationUserController>
        [HttpGet]
        public IActionResult Get([FromQuery] ApplicationUserSearch query, [FromServices] IGetApplicationUsersCommand getApplicationUsersCommand)
        {
            IEnumerable<ApplicationUserDto> applicationUsers = getApplicationUsersCommand.Execute(query);
            return Ok(applicationUsers);
        }

        // GET api/<ApplicationUserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneApplicationUserCommand getOneApplicationUserCommand)
        {
            ApplicationUserDto applicationUser = getOneApplicationUserCommand.Execute(id);
            return Ok(applicationUser);
        }

        // POST api/<ApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] ApplicationUserDto applicationUserDto, [FromServices] IAddApplicationUserCommand addApplicationUserCommand)
        {
            ApplicationUser applicationUser = mapper.Map<ApplicationUser>(applicationUserDto);
            addApplicationUserCommand.Execute(applicationUser);
            return Ok("Application user created successfully");
        }

        // PUT api/<ApplicationUserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ApplicationUserDto applicationUserDto)
        {
            applicationUserDto.Id = id;
            ApplicationUser applicationUser = mapper.Map<ApplicationUser>(applicationUserDto);
            applicationUserCommands.Update(applicationUser);
            return Ok("Application user updated successfully");
        }

        // DELETE api/<ApplicationUserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            applicationUserCommands.Delete(id);
            return Ok($"Application user with id = {id} deleted successfully");
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto loginDto, [FromServices] IGetApplicationUserByEmailCommand getApplicationUserByEmailCommand) 
        {
            ApplicationUserDto applicationUserDto = getApplicationUserByEmailCommand.Execute(loginDto.Email);

            if (Password.VerifyPassword(loginDto.Password, applicationUserDto.Password, applicationUserDto.Salt))
            {
                return Ok("Login successful");
            }
            else {
                return Unauthorized("Login failed");
            }
        }
    }
}
