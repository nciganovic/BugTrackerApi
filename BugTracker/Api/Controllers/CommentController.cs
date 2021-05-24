using Application.Commands.CommentCommands;
using Application.Dto;
using Application.Queries.CommentQueries;
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
        public IActionResult Get([FromQuery] CommentSearch search, [FromServices] IGetCommentsQuery query)
        {
            IEnumerable<CommentDto> comments = query.Execute(search);
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCommentQuery getOneCommentCommand)
        {
            CommentDto comment = getOneCommentCommand.Execute(id);
            return Ok(comment);
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
        public IActionResult Put(int id, [FromBody] CommentDto commentDto, [FromServices] IChangeCommentCommand changeCommentCommand)
        {
            commentDto.Id = id;
            Comment comment = _mapper.Map<CommentDto, Comment>(commentDto);
            changeCommentCommand.Execute(comment);
            return Ok("Comment updated successfully");
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveCommentCommand removeCommentCommand)
        {
            removeCommentCommand.Execute(id);
            return Ok("Comment deleted successfully");
        }
    }
}
