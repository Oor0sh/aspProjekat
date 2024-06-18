using aspProjekat.Application.UseCaseHandling;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public AlbumsController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SearchAlbum search,
                                 [FromServices] ISearchAlbumQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddAlbumDTO dto, [FromServices] ICreateAlbumCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
