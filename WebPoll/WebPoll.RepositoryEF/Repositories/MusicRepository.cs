using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebPoll.Model.Models;

namespace WebPoll.Repository
{
    public class MusicRepository : IRepository<Music>
    {
        private readonly MusicalContext _context;
        private readonly IMapper _mapper;

        public MusicRepository(MusicalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            EntityModel.Music music = _context.Musics.Find(id);
            _context.Musics.Remove(music);
            _context.SaveChanges();
        }

        public ICollection<Music> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Music>, ICollection<Music>>( _context.Musics.Include(m => m.Artist).Include(m => m.Genre).ToList() );
        }

        public Music GetById(int id)
        {
            var result = _context.Musics.Include(m => m.Artist).Include(m => m.Genre).Where(m => m.ID.Equals(id)).FirstOrDefault();
            return _mapper.Map<EntityModel.Music, Music>( result );
        }

        public Music GetByName(string name)
        {
            var result = _context.Musics.Include(m => m.Artist).Include(m => m.Genre).Where(m => m.Name.Equals(name)).FirstOrDefault();
            return _mapper.Map<EntityModel.Music, Music>(result);
        }

        public void Insert(Music model)
        {
            var m = _mapper.Map<Music, EntityModel.Music>(model);

            _context.Musics.Add(m);
            _context.SaveChanges();
        }

        public void Update(Music model)
        {
            EntityModel.Music oldMusic = _context.Musics.Find(model.ID);
            EntityModel.Artist artist = _mapper.Map<Artist, EntityModel.Artist>(model.Artist);
            EntityModel.Genre genre = _mapper.Map<Genre, EntityModel.Genre>(model.Genre);

            if (oldMusic == null)
            {
                //TODO: rever este tipo de casos. talvez criar excep~ções custom.
                return;
            }
            
            oldMusic.Name = model.Name;
            oldMusic.Artist = artist;
            oldMusic.ArtistID = (int)artist.ID;
            oldMusic.Genre = genre;
            oldMusic.ArtistID = (int)genre.ID;

            _context.Musics.Update(oldMusic);
            _context.SaveChanges();
        }
    }
}
