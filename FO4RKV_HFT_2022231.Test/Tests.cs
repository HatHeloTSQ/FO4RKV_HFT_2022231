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
                new Song("MAKE A MOVE","Drum and Bass",226, 1,"REAPER"),
                new Song("PULSE","Drum and Bass",196, 2,"REAPER"),
                new Song("Too Toxic to Handle","Drum and Bass",222, 3,"Kario Kay"),
                new Song("Kreate","Big Room",259,4,"Kario Kay"),
                new Song("Beastmode","Drumstep",321,5,"Teminite"),
                new Song("Animal","Dubstep",225, 6,"Teminite"),
                new Song("Promises","Dubstep",257, 7,"Nero"),
                new Song("Holdin On","Dubstep",237, 8,"Nero"),
                new Song("Tinnitus","Deathstep",294, 9,"Evilwave"),
                new Song("Misery","Deathstep",334, 10,"Evilwave"),
                new Song("Trigga Finga","Drum and Bass",244,11,"UPGRADE"),
                new Song("On You","Drum and Bass",220,12,"UPGRADE")
            }.AsQueryable());
            artistlogic = new ArtistLogic(_artistrepository.Object);
            publogic = new PublisherLogic(_publisherrepository.Object);
            songlogic = new SongLogic(_songrepository.Object);
        }
        [Test]
        public void AverageAgeTest()
        {
            double? avgage = artistlogic.AverageAge();
            Assert.That(30, Is.EqualTo(avgage));
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
            Song createdSong = new Song("CreateTest","Test123",122,100,"CreatedTest");

            songlogic.Create(createdSong);
            _songrepository.Verify(son => son.Create(createdSong), Times.Once);
        }

        [Test]
        public void DeleteSong()
        {
            Song createdSong = new Song("CreateTest", "Test123", 122, 100, "CreatedTest");
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
    }
}
