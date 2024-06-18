using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.Queries
{
    public interface IGetOrdersQuery : IQuery<OrdersSearch, PagedResponse<OrderDTO>>
    {
    }
}
