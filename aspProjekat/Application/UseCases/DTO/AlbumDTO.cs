using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public double Price { get; set; }
        public int ReleaseYear { get; set; }
        public string RecordLabel { get; set; }
        public string Format {  get; set; }
        public int Quantity { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}
