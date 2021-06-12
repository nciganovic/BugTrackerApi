using Api.Core;
using Application;
using Application.Commands.AccountCommands;
using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using Application.Queries.ApplicationUserQueries;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validators;
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
    public class AccountController : ControllerBase
    {
        private readonly JwtManager _manager;
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _executor;

        public AccountController(JwtManager manager, IMapper mapper, UseCaseExecutor executor)
        {
            _manager = manager;
            _mapper = mapper;
            _executor = executor;
        }


        // POST api/<AccountController>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            string token = _manager.MakeToken(loginDto.Email);
            return Ok(new { token });
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] RegisterDto dto
            , [FromServices] IRegisterCommand command
            , [FromServices] RegisterValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(dto);
                _executor.ExecuteCommand(command, applicationUser);
                return Ok("Application user created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }
    }
}
