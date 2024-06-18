using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class InvoiceUser
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Invoice Invoice { get; set; }
    }
}
