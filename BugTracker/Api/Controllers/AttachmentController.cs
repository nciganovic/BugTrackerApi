using Application.Dto;
using Implementation.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Implementation.ResponseMessages;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        // GET: api/<AttachmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AttachmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttachmentController>
        [HttpPost]
        public IActionResult Post([FromForm] AddAttachmentDto dto
            , [FromServices] AddAttachmentValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid) 
            {
                string fileName = CreateNewFileName(dto.File);

                string path = Path.Combine("wwwroot", "images", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.File.CopyTo(fileStream);
                }

                //Save path, name, ticketId

                return Ok();
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<AttachmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttachmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string CreateNewFileName(IFormFile file) 
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            return guid + extension;
        }
    }
}
