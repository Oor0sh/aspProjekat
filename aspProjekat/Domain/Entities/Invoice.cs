using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class Invoice : Entity
    {
        public double Total { get; set; }
        public int Quantity { get; set; }  
        public DateTime CreatedAt { get; set; }

        public ICollection<InvoiceUser> InvoiceUsers { get; set; }
        public ICollection<InvoiceAlbum> InvoiceAlbum { get; set; }
    }
}
