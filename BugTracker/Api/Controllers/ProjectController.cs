using Application.Commands;
using Application.Dto;
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
        private readonly IProjectCommands projectCommands;
        private readonly IMapper mapper;

        public ProjectController(IProjectCommands projectCommands, IMapper mapper)
        {
            this.projectCommands = projectCommands;
            this.mapper = mapper;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Project> projects = projectCommands.Read();
            return Ok(projects);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Project project = projectCommands.Read(id);
            return Ok(project);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto projectDto)
        {
            Project project = mapper.Map<Project>(projectDto);
            projectCommands.Create(project);
            return Ok("Project created successfully");
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectDto projectDto)
        {
            projectDto.Id = id;
            Project project = mapper.Map<Project>(projectDto);
            projectCommands.Update(project);
            return Ok("Project updated successfully");
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            projectCommands.Delete(id);
            return Ok($"Project with id = {id} deleted successfully");
        }
    }
}
