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

        public override void Delete(int id)
        {
            if(base.GetById(id).Musics.Count == 0)
            {
                //TODO: rever! Lançar excepção? qual?
                return;
            }

            base.Delete(id);
        }
    }
}