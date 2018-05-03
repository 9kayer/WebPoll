using System;
using System.Collections.Generic;
using WebPoll.Models;
using WebPoll.Repositories;

namespace WebPoll.Services
{
    public class ArtistService : Service<Artist>
    {
        public ArtistService(IRepository<Artist> repo) : base(repo)
        {
        }

    }
}