using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;
using WebPoll.Repository.ModelMapper;

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
            EntityModel.Artist artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public ICollection<Artist> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Artist>, ICollection<Artist>>( _context.Artists.ToList() );
        }

        public Artist GetById(int id)
        {
            return _mapper.Map<EntityModel.Artist, Artist>(_context.Artists.Find(id));
        }

        public Artist GetByName(string name)
        {
            return _mapper.Map<EntityModel.Artist, Artist>(_context.Artists.Where(a => a.Name.Equals(name)).FirstOrDefault());
        }

        public void Insert(Artist model)
        {
            _context.Artists.Add( _mapper.Map<Artist,EntityModel.Artist>(model) );
            _context.SaveChanges();
        }

        public void Update(Artist model)
        {
            EntityModel.Artist artist = _context.Artists.Find(model.ID);

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
