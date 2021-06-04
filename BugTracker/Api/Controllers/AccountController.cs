using Api.Core;
using Application;
using Application.Dto;
using Application.Queries.ApplicationUserQueries;
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
    public class AccountController : ControllerBase
    {
        private readonly JwtManager _manager;

        public AccountController(JwtManager manager)
        {
            _manager = manager;
        }


        // POST api/<AccountController>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            string token = _manager.MakeToken(loginDto.Email);
            return Ok(new { token });
        }
    }
}
