using System;
using System.Collections.Generic;
using System.Text;

namespace WebPoll.OuterRepository
{
    public interface IOuterRepository<T>
    {
        ICollection<T> GetAll();
    }
}
