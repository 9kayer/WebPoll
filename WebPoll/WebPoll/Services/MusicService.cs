using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Model.OuterModels;
using WebPoll.OuterRepository;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class MusicService : Service<Music>
    {
        private IOuterRepository<OuterArtist> _outerArtistRepository;
        private IOuterRepository<OuterGenre> _outerGenreRepository;

        public MusicService(IRepository<Music> repo, IOuterRepository<OuterArtist> outerArtistRepository, IOuterRepository<OuterGenre> outerGenreRepository) : base(repo)
        {
            _outerArtistRepository = outerArtistRepository;
            _outerGenreRepository = outerGenreRepository;
        }

        public ICollection<OuterArtist> GetArtistDataForMusicCreation()
        {
            return _outerArtistRepository.GetAll();
        }

        public ICollection<OuterGenre> GetGenreDataForMusicCreation()
        {
            return _outerGenreRepository.GetAll();
        }
    }
}