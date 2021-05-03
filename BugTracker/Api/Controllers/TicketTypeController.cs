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
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeCommands ticketTypeCommands;
        private readonly IMapper mapper;

        public TicketTypeController(ITicketTypeCommands ticketTypeCommands, IMapper mapper)
        {
            this.ticketTypeCommands = ticketTypeCommands;
            this.mapper = mapper;
        }

        // GET: api/<TicketTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TicketType> ticketType = ticketTypeCommands.Read();
            return Ok(ticketType);
        }

        // GET api/<TicketTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TicketType ticketType = ticketTypeCommands.Read(id);
            return Ok(ticketType);
        }

        // POST api/<TicketTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketTypeDto ticketTypeDto)
        {
            TicketType ticketType = mapper.Map<TicketType>(ticketTypeDto);
            ticketTypeCommands.Create(ticketType);
            return Ok("Ticket type created successfully");
        }

        // PUT api/<TicketTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketTypeDto ticketTypeDto)
        {
            ticketTypeDto.Id = id;
            TicketType ticketType = mapper.Map<TicketType>(ticketTypeDto);
            ticketTypeCommands.Update(ticketType);
            return Ok("Ticket type updated successfully");
        }

        // DELETE api/<TicketTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ticketTypeCommands.Delete(id);
            return Ok($"Ticket type with id = {id} deleted successfully");
        }
    }
}
