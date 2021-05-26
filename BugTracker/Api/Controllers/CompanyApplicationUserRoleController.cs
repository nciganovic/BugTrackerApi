using Application;
using Application.Commands.CompanyApplicationUserRoleCommands;
using Application.Dto;
using Application.Queries.CompanyApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using Domain;
using FluentValidation;
using Implementation.ResponseMessages;
using Implementation.Validators;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApplicationUserRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;
        public CompanyApplicationUserRoleController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<CompanyApplicationUserRoleController>
        [HttpGet]
        public IActionResult Get([FromBody] CompanyApplicationUserSearch search
            , [FromServices] IGetOneCompanyApplicationUserRoleQuery query)
        {
            CompanyApplicationUserDto companyApplicationUserDto = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(companyApplicationUserDto);
        }

        // GET api/<CompanyApplicationUserRoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyApplicationUserRoleController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCompanyApplicationUserRoleDto dto
            , [FromServices] IAddCompanyApplicationUserRoleCommand command
            , [FromServices] AddCompanyApplicationUserRoleValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) 
            { 
                CompanyApplicationUserRole companyApplicationUser = _mapper.Map<AddCompanyApplicationUserRoleDto, CompanyApplicationUserRole>(dto);
                _useCaseExecutor.ExecuteCommand(command, companyApplicationUser);
                return Ok("CompanyApplicationUserRole created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<CompanyApplicationUserRoleController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ChangeCompanyApplicationUserRoleDto dto
            , [FromServices] IChangeCompanyApplicationUserRoleCommand command
            , [FromServices] ChangeCompanyApplicationUserRoleValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) 
            {
                _useCaseExecutor.ExecuteCommand(command, dto);
                return Ok("CompanyApplicationUserRole update successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<CompanyApplicationUserRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
