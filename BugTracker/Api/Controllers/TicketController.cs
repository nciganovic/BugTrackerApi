using Application;
using Application.Commands.TicketCommands;
using Application.Dto;
using Application.Queries.TicketQueries;
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
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public TicketController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IActionResult Get([FromQuery] TicketSearch search, [FromServices] IGetTicketsQuery query)
        {
            IEnumerable<GetTicketDto> tickets = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(tickets);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneTicketQuery query)
        {
            GetTicketDto ticket = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(ticket);
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult Post([FromBody] AddTicketDto dto
            , [FromServices] IAddTicketCommand command
            , [FromServices] AddTicketValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Ticket ticket = _mapper.Map<Ticket>(dto);
                _useCaseExecutor.ExecuteCommand(command, ticket);
                return Ok("Ticket created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // Real PUT api/<TicketController>/5, really changes instance with given id
        [HttpPut("[action]/{id}")]
        public IActionResult RealPut(int id, [FromBody] ChangeTicketDto dto
            , [FromServices] IChangeTicketCommand command
            , [FromServices] ChangeTicketValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            
            if (result.IsValid)
            {    
                Ticket ticket = _mapper.Map<Ticket>(dto);
                _useCaseExecutor.ExecuteCommand(command, ticket);
                return Ok("Ticket changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // Fake PUT api/<TicketController>/5, creates copy of old instance with provided changes
        // and saves it as new item in database with reference on old item
        [HttpPut("[action]/{id}")]
        public IActionResult FakePut(int id, [FromBody] ChangeTicketDto dto
            , [FromServices] IAddTicketCommand command
            , [FromServices] ChangeTicketValidator validator)
        {
            dto.Id = id; //Add id to dto to validate if item exists
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Ticket ticket = _mapper.Map<Ticket>(dto);
                ticket.OriginalTicketId = id;
                ticket.Id = default; //set default value for int (0), because new instance will be created
                _useCaseExecutor.ExecuteCommand(command, ticket); 
                return Ok("Ticket changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveTicketCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Ticket removed successfully");
        }
    }
}
