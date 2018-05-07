using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model.Models;

namespace WebPoll.Repository
{
    public interface IRepository<T> where T : IModel
    {
        ICollection<T> GetAll();

        T GetById(int id);

        T GetByName(string name);

        void Insert(T model);

        void Update(T model);

        void DeleteById(int id);
    }
}
