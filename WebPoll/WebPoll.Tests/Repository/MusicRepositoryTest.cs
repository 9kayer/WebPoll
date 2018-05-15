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
    class MusicRepositoryTest
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
        public void Music_GetAll_ReturnsMusicCollection()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);

            Assert.IsNotEmpty(repository.GetAll());
        }

        [TestCase(1)]
        [TestCase(5)]
        public void Music_GetById_ValidId_ReturnMusic(int id)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            
            Assert.AreEqual(id, repository.GetById(id).ID);
        }

        [TestCase(-1)]
        [TestCase(500)]
        public void Music_GetById_InvalidId_ReturnNull(int id)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);

            Assert.IsNull(repository.GetById(id));
        }

        [TestCase("Money")]
        [TestCase("Echoes")]
        public void Music_GetByName_ValidName_ReturnsMusic(string name)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);

            Assert.AreEqual(name, repository.GetByName(name).Name);
        }

        [TestCase("Random1")]
        [TestCase("Some band not in DB")]
        public void Music_GetByName_InvalidName_ReturnsNull(string name)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);

            Assert.IsNull(repository.GetByName(name));
        }

        [Test]
        public void Music_Insert_ValidMusic_ValidatesItsInsertion()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            string name = "test";
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { Name = name, Artist = baseMusic.Artist, Genre = baseMusic.Genre };

            Assert.DoesNotThrow( () => repository.Insert(music) );
            Assert.AreEqual(music, repository.GetByName(name));
        }

        [Test]
        public void Music_Insert_DuplicateMusic_ThrowsElementInsertException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { Name = baseMusic.Name, Artist = baseMusic.Artist, Genre = baseMusic.Genre };

            Assert.Throws<ElementInsertException<Music>>(() => repository.Insert(music));
        }

        [Test]
        public void Music_Insert_WithoutName_ThrowsElementInsertException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { Artist = baseMusic.Artist, Genre = baseMusic.Genre };

            Assert.Throws<ElementInsertException<Music>>(() => repository.Insert(music));
        }

        [Test]
        public void Music_Insert_WithoutArtist_ThrowsElementInsertException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);           
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { Name = "SomeName", Genre = baseMusic.Genre };

            Assert.Throws<ElementInsertException<Music>>(() => repository.Insert(music));
        }

        [Test]
        public void Music_Insert_WithoutGenre_ThrowsElementInsertException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { Name = "SomeName", Artist = baseMusic.Artist};

            Assert.Throws<ElementInsertException<Music>>(() => repository.Insert(music));
        }

        [Test]
        public void Music_Update_ValidMusic_ValidatesItsUpdate()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            string name = "newName";
            Music music = repository.GetAll().First();

            music.Name = name;

            Assert.DoesNotThrow(() => repository.Update(music) );
            Assert.AreEqual(music, repository.GetByName(name));
        }

        [Test]
        public void Music_Update_InvalidMusicId_ThrowsElementUpdateException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            string name = "name";
            Music baseMusic = repository.GetAll().First();
            Music music = new Music { ID = -1, Name = name, Artist = baseMusic.Artist, Genre = baseMusic.Genre };

            Assert.Throws<ElementUpdateException<Music>>(() => repository.Update(music));
        }

        [Test]
        public void Music_Update_InvalidMusicName_ThrowsElementUpdateException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music music = repository.GetAll().First();
            Music secondMusic = repository.GetAll().Last();

            music.Name = secondMusic.Name;
            music.Artist = secondMusic.Artist;
            music.Genre = secondMusic.Genre;

            Assert.Throws<ElementUpdateException<Music>>(() => repository.Update(music));
        }

        [Test]
        public void Music_Update_WithoutArtist_ThrowsElementUpdateException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music music = repository.GetAll().First();

            music.Artist = null;
            
            Assert.Throws<ElementUpdateException<Music>>(() => repository.Update(music));
        }

        [Test]
        public void Music_Update_WithoutGenre_ThrowsElementUpdateException()
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            Music music = repository.GetAll().First();

            music.Genre = null;

            Assert.Throws<ElementUpdateException<Music>>(() => repository.Update(music));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Music_DeleteById_ValidId_ValidatesRemoval(int id)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);

            Assert.DoesNotThrow(() => repository.DeleteById(id));
            Assert.Null(repository.GetById(id));
        }

        [TestCase(-1)]
        [TestCase(2000)]
        public void Music_DeleteById_InvalidId_ThrowsElementDeleteException(int id)
        {
            MusicRepository repository = new MusicRepository(_context, _mapper);
            
            Assert.Throws<ElementDeleteException<Music>>(() => repository.DeleteById(id));
        }
    }
}
