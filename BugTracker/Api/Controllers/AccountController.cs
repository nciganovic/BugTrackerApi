using Api.Core;
using Application;
using Application.Commands.AccountCommands;
using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using Application.Interfaces;
using Application.Queries.ApplicationUserQueries;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IApplicationActor _actor;

        public AccountController(JwtManager manager
            , IMapper mapper
            , UseCaseExecutor executor
            , IApplicationActor actor)
        {
            _manager = manager;
            _mapper = mapper;
            _executor = executor;
            _actor = actor;
        }


        // POST api/<AccountController>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto dto
            , [FromServices] LoginValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                string token = _manager.MakeToken(dto.Email);
                return Ok(new { token });
            }
            
            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
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

        [Authorize]
        [HttpPut("[action]")]
        public IActionResult ChangeProfile([FromBody] ChangeProfileDto dto
            , [FromServices] IChangeProfileCommand command
            , [FromServices] ChangeProfileValidator validator)
        {
            dto.Id = _actor.Id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(dto);
                _executor.ExecuteCommand(command, applicationUser);
                return Ok("Application user changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }
    }
}
