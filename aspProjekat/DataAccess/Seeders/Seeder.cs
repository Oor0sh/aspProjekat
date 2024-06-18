using aspProjekat.Domain.Entities;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.DataAccess.Seeders
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new  aspProjekatContext())
            {
                context.Database.EnsureCreated();

                if (context.Genres.Any())
                {
                    return;
                }

                var genres = new Genre[]
                {
                new Genre{Name="Pop"},
                new Genre{Name="Country"},
                new Genre{Name="Rock"},
                new Genre{Name="R&B"},
                new Genre{Name="Dance"},
                new Genre{Name="Electronic"}
                };



                if (context.Formats.Any())
                {
                    return;
                }

                var formats = new Format[]
                {
                new Format{Name="CD"},
                new Format{Name = "Vinyl"}
                };



                if (context.Users.Any())
                {
                    return;
                }

                var users = new User[]
                {
                new User
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    RoleId = 1,
                    CreatedAt = DateTime.UtcNow,
                    DeletedAt = null,
                    Email= "pera.peric@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("pera123")
                 },
                new User
                {
                    FirstName = "Mika",
                    LastName = "Mikic",
                    RoleId = 2,
                    CreatedAt = DateTime.UtcNow,
                    DeletedAt = null,
                    Email= "mika.mikic@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("mika123")
                 },
                 new User
                {
                    FirstName = "Zika",
                    LastName = "Zikic",
                    RoleId = 2,
                    CreatedAt = DateTime.UtcNow,
                    DeletedAt = null,
                    Email= "zika.zikic@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("zika123")
                 },
                };



                if (context.Images.Any())
                {
                    return;
                }

                var images = new Image[]
                {
                new Image
                {
                    AlbumId = 1,
                    Source = "https://upload.wikimedia.org/wikipedia/en/9/9f/Midnights_-_Taylor_Swift.png",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Image
                {
                    AlbumId = 2,
                    Source = "https://upload.wikimedia.org/wikipedia/en/f/f2/Taylor_Swift_-_Reputation.png",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
                };


                if (context.Artists.Any())
                {
                    return;
                }

                context.Artists.Add(new Artist
                {
                    Name = "Taylor Swift"
                });

               // var artists = new Artist[]
               // {
               //new Artist
               //{
               //    Name = "Taylor Swift"
               //}
               // };

                if (context.Prices.Any())
                {
                    return;
                }

                var prices = new Price[]
                {
                new Price
                {
                    Value = 9.99
                },
                new Price
                {
                    Value = 14.99
                },
                new Price
                {
                    Value = 19.99
                },
                new Price
                {
                    Value = 49.99
                },
                new Price
                {
                    Value = 59.99
                },
                };


                if (context.Albums.Any())
                {
                    return;
                }

                var albums = new Album[]
                {
                new Album
                {
                    Name = "Midnights",
                    ArtistId = 1,
                    AddedAt = DateTime.UtcNow,
                    FormatId = 1,
                    PriceId = 2,
                    Quantity = 50,
                    RecordLabelId = 3,
                    ReleaseYear = 2022,
                    RemovedAt = null
                },
                new Album
                {
                    Name = "Reputation",
                    ArtistId = 1,
                    AddedAt = DateTime.UtcNow,
                    FormatId = 2,
                    PriceId = 4,
                    Quantity = 10,
                    RecordLabelId = 1,
                    ReleaseYear = 2022,
                    RemovedAt = null
                }
                };


                if (context.RecordLabels.Any())
                {
                    return;
                }
                var labels = new RecordLabel[]
                {
                new RecordLabel
                {
                    Name = "Big Machine Records"
                },
                new RecordLabel
                {
                    Name = "Colombia Records"
                },
                new RecordLabel
                {
                    Name = "Republic Records"
                }
                };

                context.Genres.AddRange(genres);
                context.RecordLabels.AddRange(labels);
                context.Prices.AddRange(prices);
                context.Formats.AddRange(formats);
                //context.Artists.AddRange(artists);


                context.Roles.AddRange(new Role
                {
                    Name = "Admin"
                },
                new Role
                {
                    Name = "User"
                });

                context.SaveChanges();

                context.Users.AddRange(users);

                context.RoleUseCases.AddRange(new RoleUseCase
                {
                    RoleId = 1,
                    UseCaseId = 20 //brisanje iz baze
                },
                new RoleUseCase
                {
                    RoleId = 2,
                    UseCaseId = 7 //pretraga
                },
                new RoleUseCase
                {
                    RoleId = 2,
                    UseCaseId = 6 //pretraga
                },
                 new RoleUseCase
                 {
                     RoleId = 1,
                     UseCaseId = 7 //pretraga
                 },
                new RoleUseCase
                {
                    RoleId = 1,
                    UseCaseId = 6 //pretraga
                },
                new RoleUseCase
                {
                    RoleId = 2,
                    UseCaseId = 2 //pretraga svojih ordera
                },
                new RoleUseCase
                {
                    RoleId = 1,
                    UseCaseId = 4
                }
                );

                context.SaveChanges();

                context.Albums.AddRange(albums);

                context.SaveChanges();

                context.Images.AddRange(images);

                context.AlbumsGenres.AddRange(new AlbumGenre
                {
                    AlbumId = 1,
                    GenreId = 1
                },
                new AlbumGenre
                {
                    AlbumId = 2,
                    GenreId = 1
                },
                new AlbumGenre
                {
                    AlbumId = 2,
                    GenreId = 6
                });


                context.SaveChanges();
            }
        }

         
    }
}
