using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Repository;
using WebPoll.Repository.EntityModel;

namespace WebPoll.Tests.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(MusicalContext context)
        {
            //Cria a DB caso esta nao exista
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddGenre(context);
            AddArtists(context);
            AddMusics(context);
        }

        private static void AddArtists(MusicalContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            var artists = new Artist[]
            {
                new Artist{ Name = "Pink Floyd"},
                new Artist{ Name = "Wham!"},
                new Artist{ Name = "AC/DC"},
                new Artist{ Name = "Metallica"},
                new Artist{ Name = "The Beatles"},
                new Artist{ Name = "The Beach Boys"}
            };

            foreach (Artist a in artists)
            {
                context.Artists.Add(a);
            }

            context.SaveChanges();
        }

        private static void AddGenre(MusicalContext context)
        {
            if (context.Genres.Any())
            {
                return;
            }

            var genres = new Genre[]
            {
                new Genre{Name = "Prog Rock"},
                new Genre{Name = "Pop"},
                new Genre{Name = "Metal"},
                new Genre{Name = "Hard Rock"},
                new Genre{Name = "Pop Rock"},
                new Genre{Name = "Acid Rock"}
            };

            foreach(Genre g in genres)
            {
                context.Genres.Add(g);
            }

            context.SaveChanges();
        }
        private static void AddMusics(MusicalContext context)
        {

            if (context.Musics.Any())
            {
                return;
            }

            var musics = new Music[]
            {
                new Music{ Name = "Echoes", ArtistID = 1, GenreID = 1},
                new Music{ Name = "Time", ArtistID = 1, GenreID = 1},
                new Music{ Name = "Astronomy Domine", ArtistID = 1, GenreID = 6},
                new Music{ Name = "Everything She Wants", ArtistID = 2, GenreID = 2},
                new Music{ Name = "I'm Your Man", ArtistID = 2, GenreID = 2},
                new Music{ Name = "Back In Black", ArtistID = 3, GenreID = 4},
                new Music{ Name = "Master Of Puppets", ArtistID = 4, GenreID = 3},
                new Music{ Name = "Call Of Ktulu", ArtistID = 4, GenreID = 3},
                new Music{ Name = "Enter Sandman", ArtistID = 4, GenreID = 4},
                new Music{ Name = "Love Me Do", ArtistID = 5, GenreID = 5},
                new Music{ Name = "Strawberry Fields Forever", ArtistID = 5, GenreID = 5},
                new Music{ Name = "A Day In Life", ArtistID = 5, GenreID = 5},
                new Music{ Name = "Good Vibrations", ArtistID = 6, GenreID = 5},
                new Music{ Name = "Sloop John B", ArtistID = 6, GenreID = 5}
            };

            foreach (Music m in musics)
            {
                context.Musics.Add(m);
            }

            context.SaveChanges();
        }
    }
}
