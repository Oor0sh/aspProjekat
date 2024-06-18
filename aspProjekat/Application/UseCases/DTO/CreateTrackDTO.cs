using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.DTO
{
    public class CreateTrackDTO
    {
        public string Title { get; set; }
        public double Duration { get; set; }
        public int AlbumId { get; set; }
    }
}
