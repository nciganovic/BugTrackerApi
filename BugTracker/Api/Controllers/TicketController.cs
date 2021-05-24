﻿using Application;
using Application.Commands.TicketCommands;
using Application.Dto;
using Application.Queries.TicketQueries;
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
            IEnumerable<TicketDto> tickets = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(tickets);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneTicketQuery query)
        {
            TicketDto ticket = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(ticket);
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult Post([FromBody] TicketDto ticketDto, [FromServices] IAddTicketCommand command)
        {
            Ticket ticket = _mapper.Map<Ticket>(ticketDto);
            _useCaseExecutor.ExecuteCommand(command, ticket);
            return Ok("Ticket created successfully");
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketDto ticketDto, [FromServices] IChangeTicketCommand command)
        {
            ticketDto.Id = id;
            Ticket ticket = _mapper.Map<Ticket>(ticketDto);
            _useCaseExecutor.ExecuteCommand(command, ticket);
            return Ok("Ticket changed successfully");
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
