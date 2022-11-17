using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Repository.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        IQueryable<T> ReadAll();
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }
}
