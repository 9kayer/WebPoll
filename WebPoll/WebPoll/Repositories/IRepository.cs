using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPoll.Repositories
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();

        T GetById(int id);

        void Insert(T model);

        void Update(T model);

        void DeleteById(int id);
    }
}
