using aspProjekat.Application.UseCaseHandling;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.Application.UseCases.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public OrdersController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        //GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrdersSearch search,
                                 [FromServices] IGetOrdersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }


        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDTO dto, [FromServices] ICreateOrderCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
