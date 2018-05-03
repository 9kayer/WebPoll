using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public abstract class Service<M> where M : IModel
    {
        private IRepository<M> _repo;

        public Service(IRepository<M> repo)
        {
            _repo = repo;
        }

        public virtual ICollection<M> GetAll()
        {
            return _repo.GetAll();
        }

        public virtual void Delete(int id)
        {
            _repo.DeleteById(id);
        }

        public virtual M GetById(int id)
        {
            return _repo.GetById(id);
        }

        public virtual void Update(M model)
        {
            _repo.Update(model);
        }

        public virtual void Create(M model)
        {
            _repo.Insert(model);
        }
    }
}
