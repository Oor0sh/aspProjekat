using aspProjekat.Application.UseCases;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Queries
{
    public class EfSearchAlbumQuery : EfUseCase ,ISearchAlbumQuery
    {
        public EfSearchAlbumQuery(aspProjekatContext context) : base(context) { }

        public int Id => 7;

        public string Name => "Album search";

        public PagedResponse<AlbumDTO> Execute(SearchAlbum search)
        {

            IQueryable<Album> query = Context.Albums;

            return query.ToPagedResponse<Album, AlbumDTO>(search, x => new AlbumDTO
            {
                Id =  x.Id,
                Artist = x.Artist.Name,
                Title = x.Name,
                Price = x.Price.Value,
                ReleaseYear = x.ReleaseYear,
                RecordLabel = x.RecordLabel.Name,
                Genres = x.AlbumGenres.Select(x=>x.Genre.Name).ToList(),
                Format = x.Format.Name,
                Quantity=  x.Quantity
            }
            );
        }
    }
}
