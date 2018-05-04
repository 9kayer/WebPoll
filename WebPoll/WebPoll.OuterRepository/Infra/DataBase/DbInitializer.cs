using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.OuterRepository.EntityModel;

namespace WebPoll.OuterRepository
{
    public static class DbInitializer
    {
        public static void Initialize(OuterContext context)
        {
            //Cria a DB caso esta nao exista
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddGenre(context);
            AddArtists(context);
        }

        private static void AddArtists(OuterContext context)
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
                new Artist{ Name = "The Beach Boys"},
                new Artist{ Name = "Limp Bizkit"},
                new Artist{ Name = "Slipknot"},
                new Artist{ Name = "Frank Sinatra"},
                new Artist{ Name = "Dean Martin"},
                new Artist{ Name = "The Doors"},
                new Artist{ Name = "John Mayer"},
                new Artist{ Name = "Imagine Dragons"},
                new Artist{ Name = "Bruce Springsteen"},
                new Artist{ Name = "Duran Duran"},
                new Artist{ Name = "Depeche Mode"},
                new Artist{ Name = "Nirvana"},
                new Artist{ Name = "Pearl Jam"},
                new Artist{ Name = "Oasis"},
                new Artist{ Name = "Blur"},
                new Artist{ Name = "Santana"},
                new Artist{ Name = "Foo Fighters"},
                new Artist{ Name = "Guns N'Roses"},
                new Artist{ Name = "Xutos & Pontapés"},
                new Artist{ Name = "Amália Rodrigues"},
                new Artist{ Name = "Michael Bublé"}
            };

            foreach (Artist a in artists)
            {
                context.Artists.Add(a);
            }

            context.SaveChanges();
        }

        private static void AddGenre(OuterContext context)
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
                new Genre{Name = "Acid Rock"},
                new Genre{Name = "KPop"},
                new Genre{Name = "New Wave"},
                new Genre{Name = "Swing"},
                new Genre{Name = "Jazz"},
                new Genre{Name = "Blues"},
                new Genre{Name = "R&B"},
                new Genre{Name = "HipHop"},
                new Genre{Name = "Rap"},
                new Genre{Name = "Brit Rock"},
                new Genre{Name = "Classic"},
            };

            foreach(Genre g in genres)
            {
                context.Genres.Add(g);
            }

            context.SaveChanges();
        }
    }
}
