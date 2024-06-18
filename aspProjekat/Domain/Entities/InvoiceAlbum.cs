using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class InvoiceAlbum
    {
        public int InvoiceId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }


        public Album Album { get; set; }
        public Invoice Invoice { get; set; }
    }
}
