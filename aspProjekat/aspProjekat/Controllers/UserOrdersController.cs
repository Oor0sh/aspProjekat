using aspProjekat.Application.UseCaseHandling;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {

        private aspProjekatContext _context;
        private IQueryHandler _queryHandler;

        public UserOrdersController(aspProjekatContext context, IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }

        // GET api/<UserOrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(OrdersSearch search, [FromServices] ISearchUserOrders query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // POST api/<UserOrdersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserOrdersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserOrdersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
