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
    public class RoleController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RoleController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, [FromServices] IGetRolesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoleQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto, [FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
