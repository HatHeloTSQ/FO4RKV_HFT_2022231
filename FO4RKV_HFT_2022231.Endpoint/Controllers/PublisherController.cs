using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FO4RKV_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic publisherlogic;

        public PublisherController(IPublisherLogic publisherlogic)
        {
            this.publisherlogic = publisherlogic;
        }

        [HttpGet("mostpopularcountry")]
        public string MostPopularCountry()
        {
            return this.publisherlogic.MostPopularCountry();
        }

        [HttpGet("studioartists")]
        public string ArtistsOfStudio(string studioName)
        {
            return this.publisherlogic.ArtistsOfStudio(studioName);
        }

        [HttpGet("codeofcountry")]
        public string MostGenreByCountry(string countryCode)
        {
            return this.publisherlogic.MostGenreByCountry(countryCode);
        }

        [HttpGet("fulllength")]
        public int FullSongLengthOfStudio(int studioID)
        {
            return this.publisherlogic.FullSongLengthOfStudio(studioID);
        }

            [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.publisherlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return this.publisherlogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            this.publisherlogic.Create(value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Publisher value)
        {
            this.publisherlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.publisherlogic.Delete(id);
        }
    }
}
