using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class ArtistService : Service<Artist>
    {
        public ArtistService(IRepository<Artist> repo) : base(repo)
        {
        }

    }
}