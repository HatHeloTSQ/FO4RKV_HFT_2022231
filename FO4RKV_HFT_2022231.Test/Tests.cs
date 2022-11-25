using NUnit.Framework;
using Moq;
using System;
using FO4RKV_HFT_2022231.Logic.Classes;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace FO4RKV_HFT_2022231.Test
{
    [TestFixture]
    public class Tests
    {
        ArtistLogic artistlogic;
        Mock<IRepository<Artist>> _artistrepository;
        PublisherLogic publogic;
        Mock<IRepository<Publisher>> _publisherrepository;
        SongLogic songlogic;
        Mock<IRepository<Song>> _songrepository;

        [SetUp]
        public void Initialize()
        {
            _artistrepository = new Mock<IRepository<Artist>>();
            _artistrepository.Setup(artist => artist.ReadAll()).Returns(new List<Artist>()
            {
                new Artist(20, "REAPER",  6, 28),
                new Artist(21, "Kario Kay",6, 21 ),
                new Artist(22, "Teminite", 7, 25),
                new Artist(23, "Nero", 7, 38),
                new Artist(24, "Evilwave", 8, 24),
                new Artist(25, "UPGRADE", 9, 44)
            }.AsQueryable());
            _publisherrepository = new Mock<IRepository<Publisher>>();
            _publisherrepository.Setup(artist => artist.ReadAll()).Returns(new List<Publisher>()
            {
                new Publisher("UK", "Metalheadz",6),
                new Publisher("NO", "Beatservice Records",7),
                new Publisher("UK","Critical Music",8),
                new Publisher("NZ","Uprising Records",9)
            }.AsQueryable());
            _songrepository = new Mock<IRepository<Song>>();
            _songrepository.Setup(artist => artist.ReadAll()).Returns(new List<Song>()
            {
                new Song("MAKE A MOVE","Drum and Bass",226, 1,20),
                new Song("PULSE","Drum and Bass",196, 2,20),
                new Song("Too Toxic to Handle","Drum and Bass",222, 3,21),
                new Song("Kreate","Big Room",259,4,21),
                new Song("Beastmode","Drumstep",321,5,22),
                new Song("Animal","Dubstep",220, 6,22),
                new Song("Promises","Dubstep",257, 7,23),
                new Song("Holdin On","Dubstep",237, 8,23),
                new Song("Tinnitus","Deathstep",294, 9,24),
                new Song("Misery","Deathstep",334, 10,24),
                new Song("Trigga Finga","Drum and Bass",244,11,25),
                new Song("On You","Drum and Bass",220,12,25)
            }.AsQueryable());
            artistlogic = new ArtistLogic(_artistrepository.Object);
            publogic = new PublisherLogic(_publisherrepository.Object);
            songlogic = new SongLogic(_songrepository.Object);
        }
        
        [Test]
        public void CreatePublisher()
        {
            Publisher createdPublisher = new Publisher("HUN","CreateTest",111);

            publogic.Create(createdPublisher);
            _publisherrepository.Verify(pub => pub.Create(createdPublisher), Times.Once);

        }
        [Test]
        public void CreateArtist()
        {
            Artist createdArtist = new Artist(222,"CreateTest", 111, 100);

            artistlogic.Create(createdArtist);
            _artistrepository.Verify(art => art.Create(createdArtist), Times.Once);
        }
        [Test]
        public void CreateSong()
        {
            Song createdSong = new Song("CreateTest","Test123",122,100,12);

            songlogic.Create(createdSong);
            _songrepository.Verify(son => son.Create(createdSong), Times.Once);
        }

        [Test]
        public void DeleteSong()
        {
            Song createdSong = new Song("CreateTest", "Test123", 122, 100, 10);
            songlogic.Create(createdSong);

            songlogic.Delete(100);

            _songrepository.Verify(son => son.Delete(100), Times.Once);
        }

        [Test]
        public void DeleteArtist()
        { 
            Artist createdArtist = new Artist(100,"CreateTest", 122, 100);
            artistlogic.Create(createdArtist);

            artistlogic.Delete(100);

            _artistrepository.Verify(art => art.Delete(100), Times.Once);
        }

        [Test]
        public void OldestArtistTest()
        {
            var oldestArtist = artistlogic.YoungestOrOldestArtist('o');
            Assert.That(oldestArtist.Name.Equals("UPGRADE"));

        }

        [Test]
        public void AverageAgeTest()
        {
            double? avgage = artistlogic.AverageAge();
            Assert.That(30, Is.EqualTo(avgage));
        }

        [Test]
        public void MostPopularCountryTest()
        {
            var publisherCountry = publogic.MostPopularCountry();
            Assert.That(publisherCountry.Equals("UK"));
        }

        [Test]
        public void AvgSongLength()
        {
            var avg = songlogic.AvgLength();
            Assert.That(avg.Equals(252.5));
        }

        [Test]
        public void MostPopularGenre()
        {
            var popularity = songlogic.MostPopularGenre();
            Assert.That(popularity.Equals("Drum and Bass"));
        }
    }
}
