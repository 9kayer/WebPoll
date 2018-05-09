using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.Repository.ModelMapper;

namespace WebPoll.Service.Test.TestContainer
{
    public abstract class TestContainer<T> : IDisposable where T : IModel
    {
        public MusicalContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public Dictionary<RepositoryOperations, T> Dictionary;

        public TestContainer()
        {
            DbContextOptions<MusicalContext> options = new DbContextOptionsBuilder<MusicalContext>().UseSqlServer("Server=LPT-FA3420\\SQLEXPRESS;Database=WebPollTest;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            Context = new MusicalContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
            
            Mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));

            SetDictionary();
        }

        public abstract void SetDictionary();

        public void Dispose()
        {
            Context = null;
            Mapper = null;
            Dictionary = null;
        }
    }
}
