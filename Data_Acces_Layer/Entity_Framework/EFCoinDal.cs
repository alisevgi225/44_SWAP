using Data_Acces_Layer.Abstract;
using Data_Acces_Layer.Repository;
using EntityLayer.concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Entity_Framework
{
    public class EFCoinDal: GenericRepository<Coin>, ICoinDal
    {
    }
}
