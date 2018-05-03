using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Infra.DataBaseContext;
using WebPoll.Models;
using WebPoll.Repositories;

namespace WebPoll.RepositoryB.Repositories
{
    public class ArtistRepository : IRepository<Artist>
    {
        private readonly MusicalContext _context;

        public ArtistRepository(MusicalContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            Artist artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public ICollection<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public Artist GetById(int id)
        {
            return _context.Artists.Find(id);
        }

        public void Insert(Artist model)
        {
            _context.Artists.Add(model);
            _context.SaveChanges();
        }

        public void Update(Artist model)
        {
            Artist artist = _context.Artists.Find(model.ID);

            if(artist == null)
            {
                return;
            }

            artist.Name = model.Name;
            _context.Artists.Update(artist);
            _context.SaveChanges();
        }
    }
}
