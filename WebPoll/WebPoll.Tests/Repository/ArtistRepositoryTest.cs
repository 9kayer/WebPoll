using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.Repository.Exceptions;
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

            DbInitializer.Initialize(_context);

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        [Test]
        public void GetAll_ReturnsArtistCollection()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.IsNotEmpty(repository.GetAll());
        }

        [TestCase(1)]
        [TestCase(5)]
        public void GetById_ValidId_ReturnArtist(int id)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            
            Assert.AreEqual(id, repository.GetById(id).ID);
        }

        [TestCase(-1)]
        [TestCase(500)]
        public void GetById_InvalidId_ReturnNull(int id)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.IsNull(repository.GetById(id));
        }

        [TestCase("Pink Floyd")]
        [TestCase("Metallica")]
        public void GetByName_ValidName_ReturnsArtist(string name)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.AreEqual(name, repository.GetByName(name).Name);
        }

        [TestCase("Random1")]
        [TestCase("Some band not in DB")]
        public void GetByName_InvalidName_ReturnsNull(string name)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.IsNull(repository.GetByName(name));
        }

        [Test]
        public void Insert_ValidArtist_ValidatesItsInsertion()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            string name = "test";
            Artist artist = new Artist { Name = name };

            Assert.DoesNotThrow(() => repository.Insert(artist));
            Assert.AreEqual(artist, repository.GetByName(name));
        }

        [Test]
        public void Insert_InvalidArtist_ThrowsElementInsertException()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            string name = "Pink Floyd";
            Artist artist = new Artist { Name = name };

            Assert.Throws<ElementInsertException<Artist>>(() => repository.Insert(artist));
        }

        [Test]
        public void Update_ValidArtist_ValidatesItsUpdate()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            string name = "newName";
            Artist artist = repository.GetAll().First();

            artist.Name = name;

            Assert.DoesNotThrow(() => repository.Update(artist));
            Assert.AreEqual(artist, repository.GetByName(name));
        }

        [Test]
        public void Update_InvalidArtistId_ThrowsElementUpdateException()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            string name = "";
            Artist artist = new Artist { ID = -1, Name = name };

            Assert.Throws<ElementUpdateException<Artist>>(() => repository.Update(artist));
        }

        [Test]
        public void Update_InvalidArtistName_ThrowsElementUpdateException()
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            string name = "Metallica";
            Artist artist = repository.GetByName("Pink Floyd");

            artist.Name = name;

            Assert.Throws<ElementUpdateException<Artist>>(() => repository.Update(artist));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void DeleteById_ValidId_ValidatesRemoval(int id)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);

            Assert.DoesNotThrow(() => repository.DeleteById(id));
            Assert.Null(repository.GetById(id));
        }

        [TestCase(-1)]
        [TestCase(2000)]
        public void DeleteById_InvalidId_ThrowsElementDeleteException(int id)
        {
            ArtistRepository repository = new ArtistRepository(_context, _mapper);
            
            Assert.Throws<ElementDeleteException<Artist>>(() => repository.DeleteById(id));
        }
    }
}
