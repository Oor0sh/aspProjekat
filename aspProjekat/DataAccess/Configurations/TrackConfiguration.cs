using aspProjekat.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.DataAccess.Configurations
{
    internal class TrackConfiguration : NamedEntityConfiguration<Track>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Track> builder)
        {
            builder.Property(x => x.Duration).IsRequired();
        }
    }
}
