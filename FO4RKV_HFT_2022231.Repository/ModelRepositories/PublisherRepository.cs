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
    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {
        public PublisherRepository(MusicDbContext DataBaseContext) : base(DataBaseContext)
        {
        }

        public override Publisher Read(int id)
        {
            return mdbctx.Publishers.FirstOrDefault(x => x.StudioID == id);
        }

        public override void Update(Publisher item)
        {
            var entity = Read(item.StudioID);
            mdbctx.Entry(entity).CurrentValues.SetValues(item);
            mdbctx.SaveChanges();
        }
    }
}
