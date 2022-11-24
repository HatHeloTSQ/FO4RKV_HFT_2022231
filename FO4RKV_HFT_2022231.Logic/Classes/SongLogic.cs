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
    public class SongLogic : ISongLogic
    {
        IRepository<Song> songrepo;
        public SongLogic(IRepository<Song> songrepo)
        {
            this.songrepo = songrepo;
        }

        
        #region CRUD methods
        public void Create(Song item)
        {
            this.songrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.songrepo.Delete(id);
        }

        public Song Read(int id)
        {
            return this.songrepo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.songrepo.ReadAll();
        }

        public void Update(Song item)
        {
            this.songrepo.Update(item);
        }
        #endregion
        #region Non-CRUD methods
        public double AvgLength()
        {
            return songrepo.ReadAll().Average(a => a.Length);
        }

        public string MostPopularGenre()
        {
            var helper = songrepo.ReadAll().GroupBy(x => x.Genre).Select(m => new {
                GenreName = m.Key,
                GenresCount = m.Count()
            }).OrderBy(x => x.GenresCount).FirstOrDefault();
            return helper.GenreName;
        }
        #endregion
    }
}
