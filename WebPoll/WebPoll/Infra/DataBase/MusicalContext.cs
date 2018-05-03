using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Models;
using WebPoll.DTO;

namespace WebPoll.Infra.DataBaseContext
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
        public DbSet<Gender> Genders { get; set; }

        //Personaliza os nomes das tabelas. 
        //Se tal não for feito, o nome que elas terão será o mesmo que atribuí aos DbSet's
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().ToTable("MUSIC");
            modelBuilder.Entity<Artist>().ToTable("ARTIST");
            modelBuilder.Entity<Gender>().ToTable("GENDER");
        } 

        //Personaliza os nomes das tabelas. 
        //Se tal não for feito, o nome que elas terão será o mesmo que atribuí aos DbSet's
        public DbSet<WebPoll.DTO.ArtistDTO> ArtistDTO { get; set; }

        //Personaliza os nomes das tabelas. 
        //Se tal não for feito, o nome que elas terão será o mesmo que atribuí aos DbSet's
        public DbSet<WebPoll.DTO.MusicDTO> MusicDTO { get; set; }
        #endregion
    }
}
