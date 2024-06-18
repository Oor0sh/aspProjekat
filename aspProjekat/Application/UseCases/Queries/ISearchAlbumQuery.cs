using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases.Queries
{
    public interface ISearchAlbumQuery : IQuery<SearchAlbum, PagedResponse<AlbumDTO>>
    {
    }
}
