using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Queries
{
    public class EfGetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        public EfGetOrdersQuery(aspProjekatContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get orders";

        public PagedResponse<OrderDTO> Execute(OrdersSearch search)
        {
            IQueryable<Invoice> query = Context.Invoices;

            return query.ToPagedResponse<Invoice, OrderDTO>(search, x => new OrderDTO
            {
                Albums = x.InvoiceAlbum.Select(x=>x.Album.Name).ToList(),
                OrderID = x.Id,
                CreatedAt = x.CreatedAt
            }
            );
        }
    }
}
