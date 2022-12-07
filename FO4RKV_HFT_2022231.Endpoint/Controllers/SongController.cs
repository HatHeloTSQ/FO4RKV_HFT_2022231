using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FO4RKV_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic songlogic;

        public SongController(ISongLogic songlogic)
        {
            this.songlogic = songlogic;
        }

        [HttpGet("mostpopulargenre")]
        public string MostPopularGenre()
        {
            return this.songlogic.MostPopularGenre();
        }

        [HttpGet("averagesonglength")]
        public double? AverageSongLength()
        {
            return this.songlogic.AvgLength();
        }

        [HttpGet("pubandasong")]
        public string PubAndAOfSong(int songID)
        {
            return this.songlogic.PubAndAOfSong(songID);
        }

        [HttpGet("longerthanvalue")]
        public string ListOfSongs(int value)
        {
            return this.songlogic.ListOfSongs(value);
        }

            [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.songlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.songlogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.songlogic.Create(value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Song value)
        {
            this.songlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.songlogic.Delete(id);
        }
    }
}
