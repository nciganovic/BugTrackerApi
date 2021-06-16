using Application;
using Application.Commands;
using Application.Commands.Roles;
using Application.Dto;
using Application.Queries.RoleQueries;
using Application.Searches;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public RoleController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRolesQuery query)
        {
            IEnumerable<GetRoleDto> role = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(role);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRoleQuery query)
        {
            GetRoleDto role = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRoleDto dto
            , [FromServices] IAddRoleCommand command
            , [FromServices] AddRoleValidator addRoleValidator)
        {
            var result = addRoleValidator.Validate(dto);
            
            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeRoleDto dto
            , [FromServices] IChangeRoleCommand command
            , [FromServices] ChangeRoleValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role updated successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveRoleCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok($"Role with id = {id} deleted successfully");
        }
    }
}
