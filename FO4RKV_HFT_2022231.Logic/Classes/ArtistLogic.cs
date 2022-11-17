using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Classes
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> artistrepo;
        public ArtistLogic(IRepository<Artist> artistrepo)
        {
            this.artistrepo = artistrepo;
        }

        public void Create(Artist item)
        {
            this.artistrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.artistrepo.Delete(id);
        }

        public Artist Read(int id)
        {
            return this.artistrepo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.artistrepo.ReadAll();
        }

        public void Update(Artist item)
        {
            this.artistrepo.Update(item);
        }

        //non-crud methods
        public double? AverageAge()
        {
            return this.artistrepo.ReadAll().Average(artist => artist.Age);
        }
    }
}
