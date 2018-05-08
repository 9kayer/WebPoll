using Moq;
using System;
using System.Collections.Generic;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.Services;
using Xunit;

namespace WelPoll.Service.Test
{
    public class ArtistServiceShould
    {
        [Fact]
        public void InsertNewArtist()
        {
            Mock<IRepository<Artist>> mockRepo = new Mock<IRepository<Artist>>();
            Mock<Artist> mockArtist = new Mock<Artist>();
            List<Artist> artistList = new List<Artist>();

            mockRepo.Setup(s => s.GetAll()).Returns(artistList);
            mockRepo.Setup(s => s.Insert(mockArtist.Object)).Callback(() => artistList.Add(mockArtist.Object));

            ArtistService service = new ArtistService(mockRepo.Object);
            service.Create(mockArtist.Object);

            Assert.Equal(1, artistList.Count);            
        }
    }
}
