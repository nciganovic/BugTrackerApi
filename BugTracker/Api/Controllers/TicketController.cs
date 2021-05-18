using Application.Commands.TicketCommands;
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
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IActionResult Get([FromQuery] TicketSearch query, [FromServices] IGetTicketsCommand getTicketsCommand)
        {
            IEnumerable<TicketDto> tickets = getTicketsCommand.Execute(query);
            return Ok(tickets);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneTicketCommand getOneTicketCommand)
        {
            TicketDto ticket = getOneTicketCommand.Execute(id);
            return Ok(ticket);
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketDto ticketDto, [FromServices] IAddTicketCommand addTicketCommand)
        {
            Ticket ticket = _mapper.Map<Ticket>(ticketDto);
            addTicketCommand.Execute(ticket);
            return Ok("Ticket created successfully");
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketDto ticketDto, [FromServices] IChangeTicketCommand changeTicketCommand)
        {
            ticketDto.Id = id;
            Ticket ticket = _mapper.Map<Ticket>(ticketDto);
            changeTicketCommand.Execute(ticket);
            return Ok("Ticket changed successfully");
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveTicketCommand removeTicketCommand)
        {
            removeTicketCommand.Execute(id);
            return Ok("Ticket removed successfully");
        }
    }
}
