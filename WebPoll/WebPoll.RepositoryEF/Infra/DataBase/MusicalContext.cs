using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Repository.EntityModel;

namespace WebPoll.Repository
{
    public class MusicalContext : DbContext
    {
        public MusicalContext(DbContextOptions<MusicalContext> options) : base(options)
        {
        }

        #region TableMapping
        //Representação das tabelas da BD
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Personaliza os nomes das tabelas. 
        //Se tal não for feito, o nome que elas terão será o mesmo que atribuí aos DbSet's
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().ToTable("MUSIC");
            modelBuilder.Entity<Music>()
                        .HasIndex(m => new { m.Name, m.ArtistID, m.GenreID })
                        .IsUnique();
            modelBuilder.Entity<Music>()
                        .HasOne<Genre>(m => m.Genre)
                        .WithMany()                       
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Music>()
                        .HasOne<Artist>(m => m.Artist)
                        .WithMany(a => a.Musics)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Artist>().ToTable("ARTIST");
            modelBuilder.Entity<Artist>()
                        .HasIndex(a => a.Name)
                        .IsUnique();
            modelBuilder.Entity<Artist>()
                        .HasMany<Music>(a => a.Musics)
                        .WithOne(m => m.Artist)
                        .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Genre>().ToTable("GENRE");
            modelBuilder.Entity<Genre>()
                        .HasIndex(a => a.Name)
                        .IsUnique();
            modelBuilder.Entity<Genre>()
                        .HasMany<Music>(a => a.Musics)
                        .WithOne(m => m.Genre)
                        .OnDelete(DeleteBehavior.ClientSetNull);
        } 
        #endregion
    }
}
