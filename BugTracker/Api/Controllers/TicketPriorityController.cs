using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Domain;
using Application.Dto;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPriorityController : ControllerBase
    {
        private readonly ITicketPriorityCommands ticketPriorityCommands;
        private readonly IMapper mapper;

        public TicketPriorityController(ITicketPriorityCommands ticketPriorityCommands, IMapper mapper)
        {
            this.ticketPriorityCommands = ticketPriorityCommands;
            this.mapper = mapper;
        }

        // GET: api/<TicketPriorityController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TicketPriority> ticketPriorities = ticketPriorityCommands.Read();
            return Ok(ticketPriorities);
        }

        // GET api/<TicketPriorityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TicketPriority ticketPriority = ticketPriorityCommands.Read(id);
            return Ok(ticketPriority);
        }

        // POST api/<TicketPriorityController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketPriorityDto ticketPriorityDto)
        {
            TicketPriority ticketPriority = mapper.Map<TicketPriority>(ticketPriorityDto);
            ticketPriorityCommands.Create(ticketPriority);
            return Ok("Ticket priority created successfully");
        }

        // PUT api/<TicketPriorityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketPriorityDto ticketPriorityDto)
        {
            ticketPriorityDto.Id = id;
            TicketPriority ticketPriority = mapper.Map<TicketPriority>(ticketPriorityDto);
            ticketPriorityCommands.Update(ticketPriority);
            return Ok("Ticket priority updated successfully");
        }

        // DELETE api/<TicketPriorityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ticketPriorityCommands.Delete(id);
            return Ok($"Ticket priority with id = {id} deleted successfully");
        }
    }
}
