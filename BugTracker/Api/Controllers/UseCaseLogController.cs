using Application;
using Application.Queries.UseCaseQueries;
using Application.Searches;
using Domain;
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
    public class UseCaseLogController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseExecutor;

        public UseCaseLogController(UseCaseExecutor useCaseExecutor)
        {
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<UseCaseLogController>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search
            , [FromServices] IGetUseCaseLogsQuery query)
        {
            IEnumerable<UseCaseLog> useCaseLogs = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(useCaseLogs);
        }

        // GET api/<UseCaseLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UseCaseLogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UseCaseLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UseCaseLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
