using Application.Commands.CommentCommands;
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
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch query, [FromServices] IGetCommentsCommand getCommentsCommand)
        {
            IEnumerable<CommentDto> comments = getCommentsCommand.Execute(query);
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto commentDto, [FromServices] IAddCommentCommand addCommentCommand)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            addCommentCommand.Execute(comment);
            return Ok("Comment created successfully");
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
