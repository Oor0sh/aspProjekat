using aspProjekat.Application;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Commands
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private IApplicationUser _user;
        private CreateAlbumValidator _validator;
        public EfCreateOrderCommand(
            aspProjekatContext context,
            IApplicationUser user) : base(context)
        {
            _user = user;
        }
        public int Id => 4;

        public string Name => "Order creating";

        public void Execute(CreateOrderDTO request)
        {

            Invoice invoice = new Invoice();
            invoice.CreatedAt = DateTime.UtcNow;

            Context.Invoices.Add(invoice);


            Context.SaveChanges();

            List<InvoiceAlbum> list = new List<InvoiceAlbum>();
            foreach (int a in request.Albums)
            {
                list.Add(new InvoiceAlbum
                {
                      AlbumId = a,
                      InvoiceId = invoice.Id,
                      Quantity = request.Quantity,
                });
            }

            //da  autorizacija radi

            //Context.InvoicesUser.Add(new InvoiceUser
            //{
            //    InvoiceId = invoice.Id,
            //    UserId = _user.Id
            //});
            //dodavanje tog korisnika koji je napravio order u tabelu InvoicesUsers

            Context.InvoiceAlbums.AddRange(list);
            Context.SaveChanges();
        }
    }
}
