using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class GenreService : Service<Genre>
    {
        public GenreService(IRepository<Genre> repository) : base(repository)
        {
        }
        
    }
}