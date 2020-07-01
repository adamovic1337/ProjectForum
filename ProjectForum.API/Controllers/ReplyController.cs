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
    public class ReplyController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ReplyController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ReplyController>
        [HttpGet]
        public IActionResult Get([FromQuery] ReplySearch search, [FromServices] IGetRepliesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<ReplyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetReplyQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<ReplyController>
        [HttpPost]
        public IActionResult Post([FromBody] ReplyDto dto, [FromServices] ICreateReplyCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ReplyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReplyDto dto, [FromServices] IUpdateReplyCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ReplyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReplyCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
