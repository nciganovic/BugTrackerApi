using Application.Commands;
using Application.Commands.Roles;
using Application.Dto;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleCommands roleCommands;
        private readonly IMapper mapper;

        public RoleController(IRoleCommands roleCommands, IMapper mapper)
        {
            this.roleCommands = roleCommands;
            this.mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch query, [FromServices] IGetRolesCommand getRolesCommand)
        {
            IEnumerable<RoleDto> role = getRolesCommand.Execute(query);
            return Ok(role);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRoleCommand getOneRoleCommand)
        {
            RoleDto role = getOneRoleCommand.Execute(id);
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto roleDto, [FromServices] IAddRoleCommand addRoleCommand)
        {
            Role role = mapper.Map<Role>(roleDto);
            addRoleCommand.Execute(role);
            return Ok("Role created successfully");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto roleDto, [FromServices] IChangeRoleCommand changeRoleCommand)
        {
            roleDto.Id = id;
            Role role = mapper.Map<Role>(roleDto);
            changeRoleCommand.Execute(role);
            return Ok("Role updated successfully");
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveRoleCommand removeRoleCommand)
        {
            removeRoleCommand.Execute(id);
            return Ok($"Role with id = {id} deleted successfully");
        }
    }
}
