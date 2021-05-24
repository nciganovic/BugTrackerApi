using Application;
using Application.Commands;
using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Queries.CompanyQueries;
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
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public CompanyController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get([FromQuery] CompanySearch search, [FromServices] IGetCompaniesQuery query)
        {
            IEnumerable<CompanyDto> companies = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCompanyQuery query)
        {
            CompanyDto company = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto companyDto, [FromServices] IAddCompanyCommand command)
        {
            Company company = _mapper.Map<Company>(companyDto);
            _useCaseExecutor.ExecuteCommand(command, company);
            return Ok("Company created successfully");
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyDto companyDto, [FromServices] IChangeCompanyCommand command)
        {
            companyDto.Id = id;
            Company company = _mapper.Map<Company>(companyDto);
            _useCaseExecutor.ExecuteCommand(command, company);
            return Ok("Company updated successfully");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveCompanyCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok($"Company with id = {id} deleted successfully");
        }
    }
}
