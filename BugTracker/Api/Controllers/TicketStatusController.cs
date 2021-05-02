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
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketStatusCommands ticketStatusCommands;
        private readonly IMapper mapper;

        public TicketStatusController(ITicketStatusCommands ticketStatusCommands, IMapper mapper)
        {
            this.ticketStatusCommands = ticketStatusCommands;
            this.mapper = mapper;
        }

        // GET: api/<TicketStatusController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TicketStatus> ticketStatus = ticketStatusCommands.Read();
            return Ok(ticketStatus);
        }

        // GET api/<TicketStatusController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TicketStatus ticketStatus = ticketStatusCommands.Read(id);
            return Ok(ticketStatus);
        }

        // POST api/<TicketStatusController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketStatusDto ticketStatusDto)
        {
            TicketStatus ticketStatus = mapper.Map<TicketStatus>(ticketStatusDto);
            ticketStatusCommands.Create(ticketStatus);
            return Ok("Ticket status created successfully");
        }

        // PUT api/<TicketStatusController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketStatusDto ticketStatusDto)
        {
            ticketStatusDto.Id = id;
            TicketStatus ticketStatus = mapper.Map<TicketStatus>(ticketStatusDto);
            ticketStatusCommands.Update(ticketStatus);
            return Ok("Ticket status updated successfully");
        }

        // DELETE api/<TicketStatusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ticketStatusCommands.Delete(id);
            return Ok($"Ticket status with id = {id} deleted successfully");
        }
    }
}
