using Application;
using Application.Commands;
using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Queries.ProjectQueries;
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
    public class ProjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public ProjectController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get([FromQuery] ProjectSearch search, [FromServices] IGetProjectsQuery command)
        {
            IEnumerable<ProjectDto> projects = _useCaseExecutor.ExecuteQuery(command, search);
            return Ok(projects);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneProjectQuery query)
        {
            ProjectDto project = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(project);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto projectDto, [FromServices] IAddProjectCommand command)
        {
            Project project = _mapper.Map<Project>(projectDto);
            _useCaseExecutor.ExecuteCommand(command, project);
            return Ok("Project created successfully");
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectDto projectDto, [FromServices] IChangeProjectCommand command)
        {
            projectDto.Id = id;
            Project project = _mapper.Map<Project>(projectDto);
            _useCaseExecutor.ExecuteCommand(command, project);
            return Ok("Project updated successfully");
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveProjectCommand command)
        {
            command.Execute(id);
            return Ok($"Project with id = {id} deleted successfully");
        }
    }
}
