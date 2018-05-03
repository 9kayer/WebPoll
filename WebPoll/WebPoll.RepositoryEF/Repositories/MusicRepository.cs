using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        public ICollection<Music> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Music>, ICollection<Music>>( _context.Musics.ToList() );
        }

        public Music GetById(int id)
        {
            return _mapper.Map<EntityModel.Music, Music>( _context.Musics.Find(id) );
        }

        public void Insert(Music model)
        {
            throw new NotImplementedException();
        }

        public void Update(Music model)
        {
            throw new NotImplementedException();
        }
    }
}
