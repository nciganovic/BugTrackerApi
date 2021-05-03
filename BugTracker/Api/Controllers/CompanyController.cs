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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyCommands companyCommands;
        private readonly IMapper mapper;

        public CompanyController(ICompanyCommands companyCommands, IMapper mapper)
        {
            this.companyCommands = companyCommands;
            this.mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Company> companies = companyCommands.Read();
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Company company = companyCommands.Read(id);
            return Ok(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto companyDto)
        {
            Company company = mapper.Map<Company>(companyDto);
            companyCommands.Create(company);
            return Ok("Company created successfully");
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyDto companyDto)
        {
            companyDto.Id = id;
            Company company = mapper.Map<Company>(companyDto);
            companyCommands.Update(company);
            return Ok("Company updated successfully");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            companyCommands.Delete(id);
            return Ok($"Company with id = {id} deleted successfully");
        }
    }
}
