using Application;
using Application.Commands.CommentCommands;
using Application.Dto;
using Application.Queries.CommentQueries;
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
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _useCaseExecutor;

        public CommentController(IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search, [FromServices] IGetCommentsQuery query)
        {
            IEnumerable<CommentDto> comments = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCommentQuery query)
        {
            CommentDto comment = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCommentDto dto
            , [FromServices] IAddCommentCommand command
            , [FromServices] AddCommentValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) 
            { 
                Comment comment = _mapper.Map<Comment>(dto);
                _useCaseExecutor.ExecuteCommand(command, comment);
                return Ok("Comment created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeCommentDto dto
            , [FromServices] IChangeCommentCommand command
            , [FromServices] ChangeCommentValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) { 
                dto.Id = id;
                _useCaseExecutor.ExecuteCommand(command, dto);
                return Ok("Comment updated successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveCommentCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Comment deleted successfully");
        }
    }
}
