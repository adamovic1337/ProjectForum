using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.API.Core;
using ProjectForum.Application;
using ProjectForum.EfDataAccess;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectForum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakerController : ControllerBase
    {
        // POST api/<TestController>
        [HttpPost]
        public IActionResult Post([FromServices] IFakerData faker)
        {
            faker.AddCountries();
            faker.AddRoles();
            faker.AddUsers();
            faker.AddCategories();
            faker.AddQuestions();
            faker.AddReplies();
            faker.AddTags();
            faker.AddUseCases();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
