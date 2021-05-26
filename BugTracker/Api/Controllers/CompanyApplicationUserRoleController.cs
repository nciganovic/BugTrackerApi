using Application;
using Application.Commands.CompanyApplicationUserRoleCommands;
using Application.Dto;
using Application.Queries.CompanyApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using Domain;
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
        public IActionResult Post([FromBody] CompanyApplicationUserDto companyApplicationUserDto
            , [FromServices] IAddCompanyApplicationUserRoleCommand command)
        {
            CompanyApplicationUserRole companyApplicationUser = _mapper.Map<CompanyApplicationUserDto, CompanyApplicationUserRole>(companyApplicationUserDto);
            _useCaseExecutor.ExecuteCommand(command, companyApplicationUser);
            return Ok("CompanyApplicationUserRole created successfully");
        }

        // PUT api/<CompanyApplicationUserRoleController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CompanyApplicationUserDto companyApplicationUserDto
            , [FromServices] IChangeCompanyApplicationUserRoleCommand command)
        {
            CompanyApplicationUserRole companyApplicationUser = _mapper.Map<CompanyApplicationUserDto, CompanyApplicationUserRole>(companyApplicationUserDto);
            _useCaseExecutor.ExecuteCommand(command, companyApplicationUser);
            return Ok("CompanyApplicationUserRole update successfully");
        }

        // DELETE api/<CompanyApplicationUserRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
