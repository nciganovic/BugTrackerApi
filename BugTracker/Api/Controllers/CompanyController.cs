using Application.Commands;
using Application.Commands.CompanyCommands;
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
    public class CompanyController : ControllerBase
    {
        private readonly IMapper mapper;

        public CompanyController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get([FromQuery] CompanySearch query, [FromServices] IGetCompaniesCommand getCompaniesCommand)
        {
            IEnumerable<CompanyDto> companies = getCompaniesCommand.Execute(query);
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCompanyCommand getOneCompanyCommand)
        {
            CompanyDto company = getOneCompanyCommand.Execute(id);
            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto companyDto, [FromServices] IAddCompanyCommand addCompanyCommand)
        {
            Company company = mapper.Map<Company>(companyDto);
            addCompanyCommand.Execute(company);
            return Ok("Company created successfully");
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyDto companyDto, [FromServices] IChangeCompanyCommand changeCompanyCommand)
        {
            companyDto.Id = id;
            Company company = mapper.Map<Company>(companyDto);
            changeCompanyCommand.Execute(company);
            return Ok("Company updated successfully");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveCompanyCommand removeCompanyCommand)
        {
            removeCompanyCommand.Execute(id);
            return Ok($"Company with id = {id} deleted successfully");
        }
    }
}
