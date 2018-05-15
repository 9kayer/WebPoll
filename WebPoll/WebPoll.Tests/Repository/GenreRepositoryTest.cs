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
    class GenreRepositoryTest
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
        public void GetAll_ReturnsGenreCollection()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);

            Assert.IsNotEmpty(repository.GetAll());
        }

        [TestCase(1)]
        [TestCase(5)]
        public void GetById_ValidId_ReturnGenre(int id)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            
            Assert.AreEqual(id, repository.GetById(id).ID);
        }

        [TestCase(-1)]
        [TestCase(500)]
        public void GetById_InvalidId_ReturnNull(int id)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);

            Assert.IsNull(repository.GetById(id));
        }

        [TestCase("Prog Rock")]
        [TestCase("Pop")]
        public void GetByName_ValidName_ReturnsGenre(string name)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);

            Assert.AreEqual(name, repository.GetByName(name).Name);
        }

        [TestCase("Random1")]
        [TestCase("Some band not in DB")]
        public void GetByName_InvalidName_ReturnsNull(string name)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);

            Assert.IsNull(repository.GetByName(name));
        }

        [Test]
        public void Insert_ValidGenre_ValidatesItsInsertion()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            string name = "test";
            Genre genre = new Genre { Name = name };

            Assert.DoesNotThrow(() => repository.Insert(genre));
            Assert.AreEqual(genre, repository.GetByName(name));
        }

        [Test]
        public void Insert_InvalidGenre_ThrowsElementInsertException()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            string name = "Prog Rock";
            Genre genre = new Genre { Name = name };

            Assert.Throws<ElementInsertException<Genre>>(() => repository.Insert(genre));
        }

        [Test]
        public void Update_ValidGenre_ValidatesItsUpdate()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            string name = "newName";
            Genre genre = repository.GetAll().First();

            genre.Name = name;

            Assert.DoesNotThrow(() => repository.Update(genre));
            Assert.AreEqual(genre, repository.GetByName(name));
        }

        [Test]
        public void Update_InvalidGenreId_ThrowsElementUpdateException()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            string name = "";
            Genre genre = new Genre { ID = -1, Name = name };

            Assert.Throws<ElementUpdateException<Genre>>(() => repository.Update(genre));
        }

        [Test]
        public void Update_InvalidGenreName_ThrowsElementUpdateException()
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            string name = "Pop";
            Genre genre = repository.GetByName("Prog Rock");

            genre.Name = name;

            Assert.Throws<ElementUpdateException<Genre>>(() => repository.Update(genre));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void DeleteById_ValidId_ValidatesRemoval(int id)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);

            Assert.DoesNotThrow(() => repository.DeleteById(id) );
            Assert.Null(repository.GetById(id));
        }

        [TestCase(-1)]
        [TestCase(2000)]
        public void DeleteById_InvalidId_ThrowsElementDeleteException(int id)
        {
            GenreRepository repository = new GenreRepository(_context, _mapper);
            
            Assert.Throws<ElementDeleteException<Genre>>(() => repository.DeleteById(id));
        }
    }
}
