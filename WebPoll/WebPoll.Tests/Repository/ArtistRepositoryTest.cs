using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebPoll.Repository;
using WebPoll.Repository.ModelMapper;

namespace WebPoll.Tests.Repository
{
    [TestFixture]
    class ArtistRepositoryTest
    {

        private MusicalContext _context;
        private IMapper _mapper;
        
        [SetUp]
        public void SetUp()
        {
            DbContextOptions<MusicalContext> options = new DbContextOptionsBuilder<MusicalContext>().UseSqlServer("Server=LPT-FA3420\\SQLEXPRESS;Database=WebPollTest;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            _context = new MusicalContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        [TestCase(1)]
        [TestCase(5)]
        public void GetBy_Id_ReturnArtist(int id)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            
            Assert.Equals(id, repository.GetById(id).ID);
        }

        [TestCase("Pink FLoyd")]
        [TestCase("Metallica")]
        public void GetBy_Name_ReturnsArtist(string name)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.Equals(name, repository.GetByName(name).Name);
        }
        
    }
}
