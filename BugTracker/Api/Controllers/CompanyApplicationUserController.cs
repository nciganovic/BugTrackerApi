using Application;
using Application.Commands.CompanyApplicationUserCommands;
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
    public class CompanyApplicationUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;
        public CompanyApplicationUserController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<CompanyApplicationUserController>
        [HttpGet]
        public IActionResult Get([FromBody] CompanyApplicationUserSearch search, [FromServices] IGetOneCompanyApplicationUserQuery query)
        {
            CompanyApplicationUserDto companyApplicationUserDto = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(companyApplicationUserDto);
        }

        // GET api/<CompanyApplicationUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] CompanyApplicationUserDto companyApplicationUserDto, [FromServices] IAddCompanyApplicationUserCommand command)
        {
            CompanyApplicationUser companyApplicationUser = _mapper.Map<CompanyApplicationUserDto, CompanyApplicationUser>(companyApplicationUserDto);
            _useCaseExecutor.ExecuteCommand(command, companyApplicationUser);
            return Ok("CompanyApplicationUser created successfully");
        }

        // PUT api/<CompanyApplicationUserController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CompanyApplicationUserDto companyApplicationUserDto, [FromServices] IChangeCompanyApplicationUserCommand command)
        {
            CompanyApplicationUser companyApplicationUser = _mapper.Map<CompanyApplicationUserDto, CompanyApplicationUser>(companyApplicationUserDto);
            _useCaseExecutor.ExecuteCommand(command, companyApplicationUser);
            return Ok("CompanyApplicationUser update successfully");
        }

        // DELETE api/<CompanyApplicationUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
