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

        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.songlogic.ReadAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.songlogic.Read(id);
        }

        // POST api/<SongController>
        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.songlogic.Create(value);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Song value)
        {
            this.songlogic.Update(value);
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.songlogic.Delete(id);
        }
    }
}
