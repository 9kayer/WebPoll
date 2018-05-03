using System;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class MusicService : Service<Music>
    {
        public MusicService(IRepository<Music> repo) : base(repo)
        {
        }
    }
}