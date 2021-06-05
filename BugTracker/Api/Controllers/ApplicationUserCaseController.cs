﻿using Application;
using Application.Queries.ApplicationUserCaseQueries;
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
    public class ApplicationUserCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseExecutor;

        public ApplicationUserCaseController(UseCaseExecutor useCaseExecutor)
        {
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<ApplicationUserCaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApplicationUserCaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCasesByApplicationUserIdQuery query)
        {
            IEnumerable<int> useCaseIds = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(useCaseIds);
        }

        // POST api/<ApplicationUserCaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApplicationUserCaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApplicationUserCaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
