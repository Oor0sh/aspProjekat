using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class Genre : NamedEntity
    {
        public ICollection<AlbumGenre> GenreAlbums { get; set; } = new HashSet<AlbumGenre>();
    }
}
