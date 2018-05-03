using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;

namespace WebPoll.Repository
{
    public class GenderRepository : IRepository<Gender>
    {
        private readonly MusicalContext _context;
        private readonly IMapper _mapper;

        public GenderRepository(MusicalContext musicalContext, IMapper mapper)
        {
            _context = musicalContext;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            var gender = _context.Genders.Find(id);
            _context.Genders.Remove(gender);
            _context.SaveChanges();
        }

        public ICollection<Gender> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Gender>, ICollection<Gender>>( _context.Genders.ToList() );
        }

        public Gender GetById(int id)
        {
            return _mapper.Map<EntityModel.Gender,Gender>(_context.Genders.Find(id));
        }

        public void Insert(Gender model)
        {
            _context.Genders.Add( _mapper.Map<Gender,EntityModel.Gender>(model) );
            _context.SaveChanges();
        }

        public void Update(Gender model)
        {
            EntityModel.Gender oldGender = _context.Genders.Find(model.ID);

            if (oldGender == null)
            {
                return;
            }

            oldGender.Name = model.Name;
            _context.Genders.Update(oldGender);
            _context.SaveChanges();
        }
    }
}
