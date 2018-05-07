using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;
using WebPoll.Repository.ModelMapper;

namespace WebPoll.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly MusicalContext _context;
        private IMapper _mapper;

        public GenreRepository(MusicalContext musicalContext/*, IMapper mapper*/)
        {
            _context = musicalContext;
            //_mapper = mapper;
            _mapper = new Mapper( new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        public void DeleteById(int id)
        {
            var gender = _context.Genres.Find(id);
            _context.Genres.Remove(gender);
            _context.SaveChanges();
        }

        public ICollection<Genre> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Genre>, ICollection<Genre>>( _context.Genres.ToList() );
        }

        public Genre GetById(int id)
        {
            return _mapper.Map<EntityModel.Genre,Genre>(_context.Genres.Find(id));
        }

        public Genre GetByName(string name)
        {
            return _mapper.Map<EntityModel.Genre, Genre>(_context.Genres.Where(g => g.Name.Equals(name)).FirstOrDefault());
        }

        public void Insert(Genre model)
        {
            _context.Genres.Add( _mapper.Map<Genre,EntityModel.Genre>(model) );
            _context.SaveChanges();
        }

        public void Update(Genre model)
        {
            EntityModel.Genre oldGender = _context.Genres.Find(model.ID);

            if (oldGender == null)
            {
                return;
            }

            oldGender.Name = model.Name;
            _context.Genres.Update(oldGender);
            _context.SaveChanges();
        }
    }
}
