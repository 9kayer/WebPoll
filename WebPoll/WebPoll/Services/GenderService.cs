using System;
using System.Collections.Generic;
using WebPoll.Models;
using WebPoll.Repositories;

namespace WebPoll.Services
{
    public class GenderService : Service<Gender>
    {
        public GenderService(IRepository<Gender> repository) : base(repository)
        {
        }
        
    }
}