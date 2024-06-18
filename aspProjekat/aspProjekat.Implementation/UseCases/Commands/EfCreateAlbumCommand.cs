using aspProjekat.Application;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Commands
{
    public class EfCreateAlbumCommand : EfUseCase, ICreateAlbumCommand
    {
        private IApplicationUser _user;
        private CreateAlbumValidator _validator;
        public EfCreateAlbumCommand(
            aspProjekatContext context,
            IApplicationUser user,
            CreateAlbumValidator validator) : base(context)
        {
            _user = user;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Album adding";

        public void Execute(AddAlbumDTO request)
        {
            _validator.ValidateAndThrow(request);

            Album album = new Album();
            album.ArtistId = request.ArtistId;
            album.Quantity = request.Quantity;
            album.RecordLabelId = request.RecordLabelId;
            album.FormatId = request.Format;
            album.Name = request.Title;
            album.PriceId = request.PriceId;
            album.ReleaseYear = request.ReleaseYear;
            album.RemovedAt = null;
            album.AddedAt = DateTime.UtcNow;

            Context.Albums.Add(album);
            Context.SaveChanges();

            int idAl = album.Id;
            List<AlbumGenre> genres = new List<AlbumGenre>();
            foreach(int g in request.Genres)
            {
                genres.Add(new AlbumGenre
                {
                    AlbumId = idAl,
                    GenreId = g
                });
            }
            Context.AlbumsGenres.AddRange(genres);
            Context.SaveChanges();
        }
    }
}
