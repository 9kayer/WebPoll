using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.OuterRepository.EntityModel;

namespace WebPoll.OuterRepository
{
    public class OuterContext : DbContext
    {
        public OuterContext(DbContextOptions<OuterContext> options) : base(options)
        {
        }

        #region TableMapping
        //Representação das tabelas da BD
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Personaliza os nomes das tabelas. 
        //Se tal não for feito, o nome que elas terão será o mesmo que atribuí aos DbSet's
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().ToTable("ARTIST");
            modelBuilder.Entity<Genre>().ToTable("GENRE");
        } 
        #endregion
    }
}
