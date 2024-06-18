using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class Track : NamedEntity
    {
        public int Duration { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
