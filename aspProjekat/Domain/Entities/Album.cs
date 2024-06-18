using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class Album : NamedEntity
    {
        public int PriceId { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public int RecordLabelId { get; set; }
        public int FormatId { get; set; }
        public int Quantity { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; } = new HashSet<AlbumGenre>();
        public DateTime AddedAt { get; set; }
        public DateTime? RemovedAt { get; set; }


        public Price Price { get; set; }
        public Artist Artist { get; set; }
        public RecordLabel RecordLabel { get; set; }
        public Format Format { get; set; }
    }
}
