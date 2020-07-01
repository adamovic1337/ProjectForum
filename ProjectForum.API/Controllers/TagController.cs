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
    public class TagController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public TagController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get([FromQuery] TagSearch search, [FromServices] IGetTagsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetTagQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<TagController>
        [HttpPost]
        public IActionResult Post([FromBody] TagDto dto, [FromServices] ICreateTagCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TagDto dto, [FromServices] IUpdateTagCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
