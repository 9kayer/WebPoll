﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebPoll.Model.Models;
using WebPoll.Repository.Exceptions;

namespace WebPoll.Repository
{
    public class MusicRepository : IRepository<Music>
    {
        private readonly MusicalContext _context;
        private readonly IMapper _mapper;

        public MusicRepository(MusicalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteById(int id)
        {
            EntityModel.Music music = _context.Musics.Find(id);

            if(music == null)
            {
                throw new ElementDeleteException<Music>(id, "Element to delete doesn't exist.");
            }

            try
            {
                _context.Musics.Remove(music);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementDeleteException<Music>(id, "Unable to delete.", ex);
            }
        }

        public ICollection<Music> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Music>, ICollection<Music>>( _context.Musics.Include(m => m.Artist).Include(m => m.Genre).ToList() );
        }

        public Music GetById(int id)
        {
            var result = _context.Musics.Include(m => m.Artist).Include(m => m.Genre).Where(m => m.ID.Equals(id)).FirstOrDefault();
            return _mapper.Map<EntityModel.Music, Music>( result );
        }

        public Music GetByName(string name)
        {
            var result = _context.Musics.Include(m => m.Artist).Include(m => m.Genre).Where(m => m.Name.Equals(name)).FirstOrDefault();
            return _mapper.Map<EntityModel.Music, Music>(result);
        }

        public void Insert(Music model)
        {
            try
            {
                _context.Musics.Add(_mapper.Map<Music, EntityModel.Music>(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementInsertException<Music>(model, "Unable to insert", ex);
            }
        }

        public void Update(Music model)
        {
            if (model == null || model.Artist == null || model.Genre == null)
            {
                throw new ElementUpdateException<Music>(model, "Element incomplete.");
            }

            EntityModel.Music oldMusic = _context.Musics.Find(model.ID);
            EntityModel.Artist artist = _mapper.Map<Artist, EntityModel.Artist>(model.Artist);
            EntityModel.Genre genre = _mapper.Map<Genre, EntityModel.Genre>(model.Genre);

            if (oldMusic == null)
            {
                throw new ElementUpdateException<Music>(model, "Element to update doesn't exist.");
            }
                        
            oldMusic.Name = model.Name;
            //oldMusic.Artist = artist;
            oldMusic.ArtistID = (int)artist.ID;
            //oldMusic.Genre = genre;
            oldMusic.GenreID = (int)genre.ID;

            try
            {
                _context.Musics.Update(oldMusic);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ElementUpdateException<Music>(model, "Element to update doesn't exist.", ex);
            }
        }
    }
}
