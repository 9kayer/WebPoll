using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Infra.Persistance;
using WebPoll.Repository;

namespace WebPoll.Infra.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(MusicalContext context)
        {
            //Cria a DB caso esta nao exista
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddGender(context);
            AddMusicsAndArtists(context);
        }

        private static void AddGender(MusicalContext context)
        {
            if (context.Genders.Any())
            {
                return;
            }

            var genders = new Gender[]
            {
                new Gender{Name = "Prog Rock", ID = 1},
                new Gender{Name = "Pop", ID = 2},
                new Gender{Name = "Metal", ID = 3},
                new Gender{Name = "Hard Rock", ID = 4},
                new Gender{Name = "Pop Rock", ID = 5},
                new Gender{Name = "Acid Rock", ID = 6}
            };

            foreach(Gender g in genders)
            {
                context.Genders.Add(g);
            }

            context.SaveChanges();
        }
        private static void AddMusicsAndArtists(MusicalContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            var artists = new Artist[]
            {
                new Artist{ ID = 1, Name = "Pink Floyd"},
                new Artist{ ID = 2, Name = "Wham!"},
                new Artist{ ID = 3, Name = "AC/DC"},
                new Artist{ ID = 4, Name = "Metallica"},
                new Artist{ ID = 5, Name = "The Beatles"},
                new Artist{ ID = 6, Name = "The Beach Boys"}
            };

            foreach(Artist a in artists)
            {
                context.Artists.Add(a);         
            }
            

            if (context.Musics.Any())
            {
                return;
            }

            var musics = new Music[]
            {
                new Music{ ID = 1, Name = "Echoes", ArtistID = 1, GenderID = 1},
                new Music{ ID = 2, Name = "Time", ArtistID = 1, GenderID = 1},
                new Music{ ID = 3, Name = "Astronomy Domine", ArtistID = 1, GenderID = 6},
                new Music{ ID = 4, Name = "Everything She Wants", ArtistID = 2, GenderID = 2},
                new Music{ ID = 5, Name = "I'm Your Man", ArtistID = 2, GenderID = 2},
                new Music{ ID = 6, Name = "Back In Black", ArtistID = 3, GenderID = 4},
                new Music{ ID = 7, Name = "Master Of Puppets", ArtistID = 4, GenderID = 3},
                new Music{ ID = 8, Name = "Call Of Ktulu", ArtistID = 4, GenderID = 3},
                new Music{ ID = 9, Name = "Enter Sandman", ArtistID = 4, GenderID = 4},
                new Music{ ID = 10, Name = "Love Me Do", ArtistID = 5, GenderID = 5},
                new Music{ ID = 11, Name = "Strawberry Fields Forever", ArtistID = 5, GenderID = 5},
                new Music{ ID = 12, Name = "A Day In Life", ArtistID = 5, GenderID = 5},
                new Music{ ID = 13, Name = "Good Vibrations", ArtistID = 6, GenderID = 5},
                new Music{ ID = 14, Name = "Sloop John B", ArtistID = 6, GenderID = 5}
            };

            foreach (Music m in musics)
            {
                context.Musics.Add(m);
            }

            context.SaveChanges();
        }
    }
}
