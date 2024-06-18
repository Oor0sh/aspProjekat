using aspProjekat.Application.UseCases.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.Validators
{
    public class CreateAlbumValidator : AbstractValidator<AddAlbumDTO>
    {
        public CreateAlbumValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x=> x.ArtistId).NotEmpty();
            RuleFor(x=>x.Cover).NotEmpty().WithMessage("You need to provide an image for the album cover.");
            RuleFor(x => x.Format).NotEmpty().GreaterThan(0);
            RuleFor(x=> x.Quantity).NotEmpty();
            RuleFor(x=>x.PriceId).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.RecordLabelId).NotEmpty().GreaterThan(0);
            RuleFor(x=> x.ReleaseYear).NotEmpty().InclusiveBetween(1800,DateTime.UtcNow.Year);
        }
    }
}
