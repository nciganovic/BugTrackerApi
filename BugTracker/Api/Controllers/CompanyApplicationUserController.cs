using Application.Commands.CompanyApplicationUserCommands;
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
    public class CompanyApplicationUserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CompanyApplicationUserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<CompanyApplicationUserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CompanyApplicationUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyApplicationUserController>
        [HttpPost]
        public IActionResult Post([FromBody] CompanyApplicationUserDto companyApplicationUserDto, [FromServices] IAddCompanyApplicationUserCommand addCompanyApplicationUserCommand)
        {
            CompanyApplicationUser companyApplicationUser = _mapper.Map<CompanyApplicationUserDto, CompanyApplicationUser>(companyApplicationUserDto);
            addCompanyApplicationUserCommand.Execute(companyApplicationUser);
            return Ok("CompanyApplicationUser created successfully");
        }

        // PUT api/<CompanyApplicationUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyApplicationUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
