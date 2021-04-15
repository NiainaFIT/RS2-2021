using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    //base interface
    //T type can only be class
    public interface IReadService<T,TSearch> where T:class where TSearch:class
    {
        //public IEnumerable<Proizvod> Get();
        //public Proizvod GetById(int id);
       
        public IEnumerable<T> GetAll(TSearch search = null);
        public T GetById(int id);
        //public T Insert(T proizvod);
        //public T Update(int id, T proizvod);
    }
}
