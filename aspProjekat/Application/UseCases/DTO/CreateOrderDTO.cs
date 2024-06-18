using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.DTO
{
    public class CreateOrderDTO
    {
        public List<int> Albums { get; set; }
        public int Quantity { get; set; }
    }
}
