using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebPoll.Model.Models;
using WebPoll.Repository.Exceptions;

namespace WebPoll.Repository
{
    public class ArtistRepository : IRepository<Artist>
    {
        private readonly MusicalContext _context;
        private readonly IMapper _mapper;

        public ArtistRepository(MusicalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            EntityModel.Artist artist = _context.Artists.Include(a => a.Musics).Where(a => a.ID.Equals(id)).FirstOrDefault();

            if (artist == null)
            {
                throw new ElementDeleteException<Artist>(id, "Element to delete doesn't exist."); 
            }

            if (artist.Musics.Count > 0)
            {
                throw new ElementDeleteException<Artist>(id, "Element to delete can't be deleted because it has at least one music associated with it.");
            }

            try
            { 
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new ElementDeleteException<Artist>(id, "Unable to delete", ex);
            }
        }

        public ICollection<Artist> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Artist>, ICollection<Artist>>( _context.Artists.ToList() );
        }

        public Artist GetById(int id)
        {
            var result = _context.Artists.Include(a => a.Musics).ThenInclude(music => music.Genre).Where(a => a.ID.Equals(id)).FirstOrDefault();
            return _mapper.Map<EntityModel.Artist, Artist>(result);
        }

        public Artist GetByName(string name)
        {
            var result = _context.Artists.Include(a => a.Musics).ThenInclude(music => music.Genre).Where(a => a.Name.Equals(name)).FirstOrDefault();
            return _mapper.Map<EntityModel.Artist, Artist>(result);
        }

        public void Insert(Artist model)
        {
            try
            {
                _context.Artists.Add(_mapper.Map<Artist, EntityModel.Artist>(model));
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new ElementInsertException<Artist>(model, "Unable to insert", ex);
            }
        }

        public void Update(Artist model)
        {
            EntityModel.Artist artist = _context.Artists.Find(model.ID);

            if(artist == null)
            {
                throw new ElementUpdateException<Artist>(model, "Element to update doesn't exist");
            }

            artist.Name = model.Name;

            try
            {
                _context.Artists.Update(artist);
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new ElementUpdateException<Artist>(model, "Unable to update", ex);
            }
        }
    }
}
