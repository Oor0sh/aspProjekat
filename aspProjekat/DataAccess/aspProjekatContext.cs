using aspProjekat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.DataAccess
{
    public class aspProjekatContext : DbContext
    {
        private readonly string _connectionString;

        public aspProjekatContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public aspProjekatContext()
        {
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ProjekatASP;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<AlbumGenre>().HasKey(x => new { x.AlbumId, x.GenreId });
            modelBuilder.Entity<InvoiceAlbum>().HasKey(x => new { x.AlbumId, x.InvoiceId });
            modelBuilder.Entity<InvoiceUser>().HasKey(x => new { x.InvoiceId, x.UserId });
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId });

            modelBuilder.Entity<RoleUseCase>()
           .HasOne(ruc => ruc.Role)
           .WithMany(r => r.RoleUseCase)
           .HasForeignKey(ruc => ruc.RoleId);

            modelBuilder.Entity<AlbumGenre>()
            .HasOne(ag => ag.Album)
            .WithMany(a => a.AlbumGenres)
            .HasForeignKey(ag => ag.AlbumId);

            modelBuilder.Entity<AlbumGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(g => g.GenreAlbums)
                .HasForeignKey(ag => ag.GenreId);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<int>("Id").ValueGeneratedOnAdd();
                }
            }

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceUser> InvoicesUser { get; set; }
        public DbSet<RecordLabel> RecordLabels { get; set; }
        public DbSet<Image> Images { get; set; }   
        public DbSet<Artist>  Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AlbumGenre> AlbumsGenres { get;set; }
        public DbSet<InvoiceAlbum> InvoiceAlbums { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Domain.Entities.LogEntry> LogEntries { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
    }
}
