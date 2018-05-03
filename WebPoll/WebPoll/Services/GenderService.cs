using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class GenderService : Service<Gender>
    {
        public GenderService(IRepository<Gender> repository) : base(repository)
        {
        }
        
    }
}