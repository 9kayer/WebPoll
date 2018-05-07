using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.OuterRepository;
using WebPoll.Repository;

namespace WebPoll.Services
{
    public class MusicService : Service<Music>
    {
        private IOuterRepository<Artist> _outerArtistRepository;
        private IOuterRepository<Genre> _outerGenreRepository;
        private GenreService _genreService;
        private ArtistService _artistService;

        public MusicService(IRepository<Music> repo, IOuterRepository<Artist> outerArtistRepository, IOuterRepository<Genre> outerGenreRepository, GenreService genreService, ArtistService artistService) : base(repo)
        {
            _outerArtistRepository = outerArtistRepository;
            _outerGenreRepository = outerGenreRepository;
            _genreService = genreService;
            _artistService = artistService;
        }

        public ICollection<Artist> GetArtistDataForMusicCreation()
        {
            return _outerArtistRepository.GetAll();
        }

        public ICollection<Genre> GetGenreDataForMusicCreation()
        {
            return _outerGenreRepository.GetAll();
        }

        public override void Create(Music model)
        {
            if (ModelInvalid(model))
            {
                return;
            }

            model.Artist = GetArtistInfo(model.Artist);
            model.Genre = GetGenreInfo(model.Genre);

            base.Create(model);
        }

        private Genre GetGenreInfo(Genre genre)
        {
            Genre genreFromDB = _genreService.GetByName(genre.Name);

            if (genreFromDB == null)
            {
                _genreService.Create(genre);
                genreFromDB = _genreService.GetByName(genre.Name);
            }

            return genreFromDB;
        }

        private Artist GetArtistInfo(Artist artist)
        {
            Artist artistFromDB = _artistService.GetByName(artist.Name);

            if (artistFromDB == null)
            {
                _artistService.Create(artist);
                artistFromDB = _artistService.GetByName(artist.Name);
            }

            return artistFromDB;
        }

        private bool ModelInvalid(Music model)
        {
            if(model == null)
            {
                return true;
            }

            if(model.Artist == null || "".Equals(model.Artist.Name))
            {
                return true;
            }

            if (model.Genre == null || "".Equals(model.Genre.Name))
            {
                return true;
            }

            return false;
        }
    }
}