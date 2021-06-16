using Application;
using Application.Commands.RoleCaseCommands;
using Application.Dto;
using Application.Queries.RoleCaseQueries;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseExecutor;
        private readonly IMapper _mapper;

        public RoleCaseController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET: api/<RoleCaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoleCaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCasesByRoleIdQuery query)
        {
            IEnumerable<int> useCaseIds = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(useCaseIds);
        }

        // POST api/<RoleCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRoleCaseDto dto
            , [FromServices] IAddRoleCaseCommand command
            , [FromServices] AddRoleCaseValidator validator)
        {
            var result = validator.Validate(dto);
            
            if (result.IsValid) 
            {
                RoleUserCase applicationUserCase = _mapper.Map<RoleUserCase>(dto);
                _useCaseExecutor.ExecuteCommand(command, applicationUserCase);
                return Ok();
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<RoleCaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleCaseController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] RemoveRoleCaseDto dto
            , [FromServices] RemoveRoleCaseValidator validator
            , [FromServices] IGetOneRoleCaseQuery query
            , [FromServices] IRemoveRoleCaseCommand command)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) 
            {
                RoleUserCase roleCase = _useCaseExecutor.ExecuteQuery(query, dto);
                _useCaseExecutor.ExecuteCommand(command, roleCase);
                return Ok();
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }
    }
}
