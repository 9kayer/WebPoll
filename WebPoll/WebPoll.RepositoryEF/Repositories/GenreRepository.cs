using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebPoll.Model.Models;
using WebPoll.Repository.Exceptions;

namespace WebPoll.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly MusicalContext _context;
        private IMapper _mapper;

        public GenreRepository(MusicalContext musicalContext, IMapper mapper)
        {
            _context = musicalContext;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            var genre = _context.Genres.Include(g => g.Musics).Where(g => g.ID.Equals(id)).FirstOrDefault();

            if (genre == null)
            {
                throw new ElementDeleteException<Genre>(id, "Element to delete doesn't exist.");
            }

            if(genre.Musics.Count > 0)
            {
                throw new ElementDeleteException<Genre>(id, "Element to delete can't be deleted because it has at least one music associated with it.");
            }

            try
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementDeleteException<Genre>(id, "Unable to delete", ex);
            }
        }

        public ICollection<Genre> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Genre>, ICollection<Genre>>( _context.Genres.ToList() );
        }

        public Genre GetById(int id)
        {
            var result = _context.Genres.Find(id);
            return _mapper.Map<EntityModel.Genre,Genre>(result);
        }

        public Genre GetByName(string name)
        {
            var result = _context.Genres.Where(g => g.Name.Equals(name)).FirstOrDefault();
            return _mapper.Map<EntityModel.Genre, Genre>(result);
        }

        public void Insert(Genre model)
        {
            try
            {
                _context.Genres.Add(_mapper.Map<Genre, EntityModel.Genre>(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementInsertException<Genre>(model, "Unable to insert", ex);
            }
        }

        public void Update(Genre model)
        {
            EntityModel.Genre oldGender = _context.Genres.Find(model.ID);

            if (oldGender == null)
            {
                throw new ElementUpdateException<Genre>(model, "Element to update doesn't exist");
            }

            oldGender.Name = model.Name;

            try
            {
                _context.Genres.Update(oldGender);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementUpdateException<Genre>(model, "Unable to update", ex);
            }
        }
    }
}
