using FO4RKV_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Interface
{
    public interface IPublisherLogic
    {
        public string MostPopularCountry();
        public string ArtistsOfStudio(string studioName); //sums all artist names where country code is the queries coutnry code
        public int FullSongLengthOfStudio(int studioID); //sum of song lengths of queried studio through artists of studio
        public string MostGenreByCountry(string countryCode); //gives back the most popular genre data of a country: how many song of said genre
        void Create(Publisher item);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher item);
    }
}
