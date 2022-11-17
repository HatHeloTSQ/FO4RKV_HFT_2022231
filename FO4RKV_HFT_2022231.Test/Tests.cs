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
        ArtistLogic songlogic;
        Mock<IRepository<Artist>> _repository;

        [SetUp]
        public void Initialize()
        {
            _repository = new Mock<IRepository<Artist>>();
            _repository.Setup(artist => artist.ReadAll()).Returns(new List<Artist>()
            {
                new Artist(20, "REAPER",  4, 28),
                new Artist(21, "Kario Kay",5, 21 ),
                new Artist(29, "Teminite", 5, 25),
                new Artist(30, "Nero", 3, 37)
            }.AsQueryable());
            songlogic = new ArtistLogic(_repository.Object);
        }
        [Test]
        public void AverageAgeTest()
        { 
            double? avgage = _repository.
        }
    }
}
