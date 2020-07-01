using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForum.Application;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Queries;
using ProjectForum.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectForum.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CountryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult Get([FromQuery] CountrySearch search, [FromServices] IGetCountriesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCountryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult Post([FromBody] CountryDto dto, [FromServices] ICreateCountryCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryDto dto, [FromServices] IUpdateCountryCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCountryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
