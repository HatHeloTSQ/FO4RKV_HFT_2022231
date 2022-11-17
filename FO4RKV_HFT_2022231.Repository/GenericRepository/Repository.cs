using FO4RKV_HFT_2022231.Repository.Database;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Repository.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MusicDbContext mdbctx;

        public Repository(MusicDbContext DataBaseContext)
        {
            mdbctx = DataBaseContext;
        }

        public void Create(T item)
        {
            mdbctx.Set<T>().Add(item);
            mdbctx.SaveChanges();
        }

        public void Delete(int id)
        {
            mdbctx.Set<T>().Remove(Read(id));
            mdbctx.SaveChanges();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            IQueryable<T> otpt = mdbctx.Set<T>();
            return otpt;
        }

        public abstract void Update(T item);
    }
}
