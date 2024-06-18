using aspProjekat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.DTO
{
    public class AddAlbumDTO
    {
        public string Title { get; set; } 
        public int ArtistId { get; set; }
        public string Cover {  get; set; }
        public List<int> Genres { get; set; }
        public int PriceId { get; set; }
        public int ReleaseYear { get; set; }
        public int RecordLabelId { get; set; }
        public int Format { get; set; }
        public int Quantity { get; set; }


    }
}
