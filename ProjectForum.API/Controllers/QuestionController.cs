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
    public class QuestionController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public QuestionController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public IActionResult Get([FromQuery] QuestionSearch search, [FromServices] IGetQuestionsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetQuestionQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<QuestionController>
        [HttpPost]
        public IActionResult Post([FromBody] QuestionDto dto, [FromServices] ICreateQuestionCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] QuestionDto dto, [FromServices] IUpdateQuestionCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteQuestionCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
