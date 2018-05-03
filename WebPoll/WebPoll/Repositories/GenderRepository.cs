using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Infra.DataBaseContext;
using WebPoll.Models;

namespace WebPoll.Repositories
{
    public class GenderRepository : IRepository<Gender>
    {
        private readonly MusicalContext _context;

        public GenderRepository(MusicalContext musicalContext)
        {
            _context = musicalContext;
        }

        public void DeleteById(int id)
        {
            var gender = _context.Genders.Find(id);
            _context.Genders.Remove(gender);
            _context.SaveChanges();
        }

        public ICollection<Gender> GetAll()
        {
            return _context.Genders.ToList();
        }

        public Gender GetById(int id)
        {
            return _context.Genders.Find(id);
        }

        public void Insert(Gender model)
        {
            _context.Genders.Add(model);
            _context.SaveChanges();
        }

        public void Update(Gender model)
        {
            Gender oldGender = _context.Genders.Find(model.ID);

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
