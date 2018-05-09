using Moq;
using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.Services;
using Xunit;

namespace WelPoll.Service.Test
{
    public class ArtistServiceShould : IClassFixture<ArtistServiceShould.TestContainer>
    {
        private TestContainer _testContainer;

        public ArtistServiceShould(TestContainer testContainer)
        {
            _testContainer = testContainer;
        }
        
        [Fact]
        public void GetAllList()
        {
            _testContainer.MockRepo.Setup(s => s.GetAll()).Returns(_testContainer.ArtistList);

            Assert.Equal(_testContainer.ArtistList.Count, _testContainer.Service.GetAll().Count);
            Assert.True(_testContainer.ArtistList.Equals( _testContainer.Service.GetAll()));
        }
        
        [Fact]
        public void InsertNewArtist()
        {
            Artist artist = new Artist();

            _testContainer.MockRepo.Setup(s => s.GetAll()).Returns(_testContainer.ArtistList);
            _testContainer.MockRepo.Setup(s => s.Insert(artist)).Callback(() => _testContainer.ArtistList.Add(artist));

            int count = _testContainer.ArtistList.Count;

            ArtistService service = new ArtistService(_testContainer.MockRepo.Object);
            service.Create(artist);
            
            Assert.Equal(count + 1, _testContainer.ArtistList.Count);
            Assert.Contains(artist, _testContainer.ArtistList);
        }

        [Fact]
        public void GetById()
        {
            int id = 1;
            Artist artist = new Artist { ID = id };

            _testContainer.MockRepo.Setup(s => s.Insert(artist)).Callback(() => _testContainer.ArtistList.Add(artist));
            _testContainer.MockRepo.Setup(s => s.GetById(id)).Returns(new Artist { ID = artist.ID, Name = artist.Name, Musics = artist.Musics });

            Assert.Equal(artist, _testContainer.Service.GetById(id));
        }

        [Fact]
        public void UpdateArtist()
        {
            int id = 2;
            string name = "my name";
            Artist artist = new Artist { ID = id };
            Artist artistUpdated = new Artist { ID = id, Name = name };

            _testContainer.MockRepo.Setup(s => s.Insert(artist)).Callback(() => _testContainer.ArtistList.Add(artist));
            _testContainer.MockRepo.Setup(s => s.Update(artistUpdated)).Callback( () => { _testContainer.ArtistList.Remove(artist); _testContainer.ArtistList.Add(artistUpdated); } );
            _testContainer.MockRepo.Setup(s => s.GetById(id)).Returns(new Artist { ID = artistUpdated.ID, Name = artistUpdated.Name, Musics = artistUpdated.Musics });

            _testContainer.Service.Create(artist);
            _testContainer.Service.Update(artistUpdated);

            Assert.Equal(artistUpdated, _testContainer.Service.GetById(id));
        }

        [Fact]
        public void DeleteArtist()
        {
            int count = _testContainer.ArtistList.Count;
            int id = 2;

            _testContainer.MockRepo.Setup(s => s.DeleteById(id)).Callback(() => _testContainer.ArtistList.Remove(new Artist { ID = id }));
            _testContainer.MockRepo.Setup((s) => s.GetById(id)).Returns(() => (_testContainer.ArtistList as List<Artist>).Find(a => a.ID == id));

            _testContainer.Service.Delete(id);

            Assert.Equal(count - 1, _testContainer.ArtistList.Count);
            Assert.Null(_testContainer.Service.GetById(id));
        }
        

        public class TestContainer :IDisposable
        {
            public Mock<IRepository<Artist>> MockRepo { get; set; }
            public IList<Artist> ArtistList { get; set; }
            public ArtistService Service { get; set; }

            public TestContainer()
            {
                MockRepo = new Mock<IRepository<Artist>>();
                ArtistList = new List<Artist>();
                Service = new ArtistService(MockRepo.Object);
            }

            public void Dispose()
            {
                MockRepo = null;
                ArtistList = null;
                Service = null;
            }
        }
    }
}
