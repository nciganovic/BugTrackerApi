using Application;
using Application.Commands;
using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Queries.CompanyQueries;
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

        // GET: api/<CompanyController>d
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
        public IActionResult Post([FromBody] AddCompanyDto dto
            , [FromServices] IAddCompanyCommand command
            , [FromServices] AddCompanyValidator addCompanyValidator)
        {
            var result = addCompanyValidator.Validate(dto);

            if (result.IsValid) 
            {
                Company company = _mapper.Map<Company>(dto);
                _useCaseExecutor.ExecuteCommand(command, company);
                return Ok("Company created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeCompanyDto dto
            , [FromServices] IChangeCompanyCommand command
            , [FromServices] ChangeCompanyValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid) 
            { 
                Company company = _mapper.Map<Company>(dto);
                _useCaseExecutor.ExecuteCommand(command, company);
                return Ok("Company updated successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
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
