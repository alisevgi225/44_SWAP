using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Abstract
{
    public interface IGenericDal_<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}
