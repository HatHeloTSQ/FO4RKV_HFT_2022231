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
    public class SongRepository : Repository<Song>, IRepository<Song>
    {
        public SongRepository(MusicDbContext DataBaseContext) : base(DataBaseContext)
        {
        }

        public override Song Read(int id)
        {
            return mdbctx.Songs.FirstOrDefault(x => x.SongID == id);
        }

        public override void Update(Song item)
        {
            var entity = Read(item.SongID);
            mdbctx.Entry(entity).CurrentValues.SetValues(item);
            mdbctx.SaveChanges();
        }
    }
}
