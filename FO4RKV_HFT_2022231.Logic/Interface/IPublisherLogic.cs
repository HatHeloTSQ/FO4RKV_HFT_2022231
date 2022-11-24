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
        public Publisher MostPopularCountry();
        public int PublisherArtistCount(int paramStudioName);
        void Create(Publisher item);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher item);
    }
}
