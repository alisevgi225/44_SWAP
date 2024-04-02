using Data_Acces_Layer.Abstract;
using Data_Acces_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Repository
{
    public class GenericRepository<T> : IGenericDal_<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();

        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var   c=new Context();
            c.Update(t);
            c.SaveChanges();

        }
    }
}
