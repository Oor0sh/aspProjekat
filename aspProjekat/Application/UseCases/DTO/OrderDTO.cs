using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set;}
        //public int UserID { get; set;}
        //public string FirstName { get; set;}
        //public string LastName { get; set;}
        //public string Email {  get; set;}

        public IEnumerable<string> Albums { get; set;}
        public DateTime CreatedAt { get; set;}
    }
}
