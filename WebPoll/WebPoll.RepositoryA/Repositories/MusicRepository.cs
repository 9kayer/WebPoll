using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Infra.DataBaseContext;
using WebPoll.Models;

namespace WebPoll.Repositories
{
    public class MusicRepository : IRepository<Music>
    {
        private readonly MusicalContext _context;

        public MusicRepository(MusicalContext context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Music> GetAll()
        {
            return _context.Musics.ToList();
        }

        public Music GetById(int id)
        {
            return _context.Musics.Find(id);
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
