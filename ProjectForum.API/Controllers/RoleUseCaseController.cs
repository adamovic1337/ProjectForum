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
    public class RoleUseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RoleUseCaseController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<RoleUseCaseController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleUseCaseSearch search, [FromServices] IGetRoleUseCaseQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<RoleUseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleUseCaseDto dto, [FromServices] ICreateRoleUserCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RoleUseCaseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleUseCaseDto dto, [FromServices] IUpdateRoleUseCaseCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<RoleUseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
