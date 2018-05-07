using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;
using WebPoll.Repository.ModelMapper;

namespace WebPoll.Repository
{
    public class MusicRepository : IRepository<Music>
    {
        private readonly MusicalContext _context;
        private readonly IMapper _mapper;

        public MusicRepository(MusicalContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
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
            return _mapper.Map<EntityModel.Music, Music>( _context.Musics.Find(id));
        }

        public Music GetByName(string name)
        {
            return _mapper.Map<EntityModel.Music, Music>(_context.Musics.Where(m => m.Name.Equals(name)).FirstOrDefault());
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
