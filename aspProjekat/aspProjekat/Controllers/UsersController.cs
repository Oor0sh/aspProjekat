using aspProjekat.Application.UseCaseHandling;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public UsersController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search,
                                 [FromServices] IGetUsersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
