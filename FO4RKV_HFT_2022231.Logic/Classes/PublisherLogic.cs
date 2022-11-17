using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Logic.Classes
{
    public class PublisherLogic
    {
        IRepository<Publisher> pubrepo;
        public PublisherLogic(IRepository<Publisher> pubrepo)
        {
            this.pubrepo = pubrepo;
        }

        public void Create(Publisher item)
        {
            this.pubrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.pubrepo.Delete(id);
        }

        public Publisher Read(int id)
        {
            return this.pubrepo.Read(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.pubrepo.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.pubrepo.Update(item);
        }
    }
}
