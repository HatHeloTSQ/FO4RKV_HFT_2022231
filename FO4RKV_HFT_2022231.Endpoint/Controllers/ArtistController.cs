﻿using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FO4RKV_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
        }

        [HttpGet("avgage")]
        public double? AverageAgeOfAllArtists()
        {
            return this.artistLogic.AverageAge();
        }

        [HttpGet("yoro")]
        public Artist YoungestOrOldestArtist(char YorO)
        {
            return artistLogic.YoungestOrOldestArtist(YorO);
        }

        [HttpGet("artistsonglength")]
        public List<Song> LandSArtistSong(string artistName)
        {
            return this.artistLogic.LandSArtistSong(artistName);
        }

        [HttpGet("queriedgenre")]
        public string MostSongOfQueriedGenre(string genre)
        {
            return this.artistLogic.MostSongOfQueriedGenre(genre);
        }

        [HttpGet]
        public IEnumerable<Artist> ReadAll()
        {
            return this.artistLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Artist Read(int id)
        {
            return this.artistLogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Artist value)
        {
            this.artistLogic.Create(value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Artist id)
        {
            this.artistLogic.Update(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.artistLogic.Delete(id);
        }
    }
}
