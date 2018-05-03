using System;
using WebPoll.Models;
using WebPoll.Repositories;

namespace WebPoll.Services
{
    public class MusicService : Service<Music>
    {
        public MusicService(IRepository<Music> repo) : base(repo)
        {
        }
    }
}