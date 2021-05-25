using Application.Commands;
using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Hash;
using Application.Searches;
using Application.Queries.ApplicationUserQueries;
using Application;
using Implementation.Validators;
using Implementation.ResponseMessages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public ApplicationUserController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<ApplicationUserController>
        [HttpGet]
        public IActionResult Get([FromQuery] ApplicationUserSearch search, [FromServices] IGetApplicationUsersQuery query)
        {
            IEnumerable<ApplicationUserDto> applicationUsers = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(applicationUsers);
        }

        // GET api/<ApplicationUserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneApplicationUserQuery query)
        {
            ApplicationUserDto applicationUser = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(applicationUser);
        }

        // POST api/<ApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateApplicationUserDto dto
            , [FromServices] IAddApplicationUserCommand command
            , [FromServices] CreateApplicationUserValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) { 
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(dto);
                _useCaseExecutor.ExecuteCommand(command, applicationUser);
                return Ok("Application user created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<ApplicationUserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ApplicationUserDto applicationUserDto, [FromServices] IChangeApplicationUserCommand command)
        {
            applicationUserDto.Id = id;
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(applicationUserDto);
            _useCaseExecutor.ExecuteCommand(command, applicationUser);
            return Ok("Application user updated successfully");
        }

        // DELETE api/<ApplicationUserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveApplicationUserCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok($"Application user with id = {id} deleted successfully");
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto loginDto, [FromServices] IGetApplicationUserByEmailQuery command) 
        {
            ApplicationUserDto applicationUserDto = _useCaseExecutor.ExecuteQuery(command, loginDto.Email);

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
