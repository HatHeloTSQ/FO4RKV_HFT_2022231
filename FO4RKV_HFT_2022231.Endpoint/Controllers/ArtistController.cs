﻿using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FO4RKV_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
        }


        // GET: api/<ArtistController>
        [HttpGet]
        public IEnumerable<Artist> ReadAll()
        {
            return this.artistLogic.ReadAll();
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public Artist Read(int id)
        {
            return this.artistLogic.Read(id);
        }

        // POST api/<ArtistController>
        [HttpPost]
        public void Create([FromBody] Artist value)
        {
            this.artistLogic.Create(value);
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Artist value)
        {
            this.artistLogic.Update(value);
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.artistLogic.Delete(id);
        }
    }
}