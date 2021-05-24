using Application;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Dto;
using Application.Queries.ProjectApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using Domain;
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
    public class ProjectApplicationUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public ProjectApplicationUserController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<ProjectApplicationUserController>
        [HttpGet("[action]")]
        public IActionResult GetApplicationUsers(int projectId, [FromServices] IGetApplicationUsersForProjectQuery query)
        {
            IEnumerable<ApplicationUserDto> applicationUserDtos = _useCaseExecutor.ExecuteQuery(query, projectId);
            return Ok(applicationUserDtos);
        }

        // GET api/<ProjectApplicationUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectApplicationUserDto dto, [FromServices] IAddProjectApplicationUserCommand command)
        {
            ProjectApplicationUser projectApplicationUser = _mapper.Map<ProjectApplicationUserDto, ProjectApplicationUser>(dto);
            _useCaseExecutor.ExecuteCommand(command, projectApplicationUser);
            return Ok("ProjectApplicationUser created successfully");
        }

        // PUT api/<ProjectApplicationUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectApplicationUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
