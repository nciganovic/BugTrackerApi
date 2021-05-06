using Application.Commands;
using Application.Dto;
using AutoMapper;
using Domain;
using EfCommands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Get()
        {
            IEnumerable<ApplicationUser> applicationUsers = applicationUserCommands.Read();
            return Ok(applicationUsers);
        }

        // GET api/<ApplicationUserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApplicationUser applicationUser = applicationUserCommands.Read(id);
            return Ok(applicationUser);
        }

        // POST api/<ApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] ApplicationUserDto applicationUserDto)
        {
            ApplicationUser applicationUser = mapper.Map<ApplicationUser>(applicationUserDto);
            applicationUserCommands.Create(applicationUser);
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
    }
}
