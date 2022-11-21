using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.Database;
using FO4RKV_HFT_2022231.Repository.GenericRepository;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Repository.ModelRepositories
{
    public class ArtistRepository : Repository<Artist>, IRepository<Artist>
    {
        public ArtistRepository(MusicDbContext DataBaseContext) : base(DataBaseContext)
        {
        }

        public override Artist Read(int id)
        {
            return mdbctx.Artists.FirstOrDefault(x => x.ArtistID == id);
        }

        public override void Update(Artist item)
        {
            var entity = Read(item.ArtistID);
            mdbctx.Entry(entity).CurrentValues.SetValues(item);
            mdbctx.SaveChanges();
        }
    }
}
