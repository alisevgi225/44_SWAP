using Business_Layer.Abstract;
using Data_Acces_Layer.Abstract;
using EntityLayer.concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class CoinManager : IGenericService<Coin>, ICoinService
    {
        ICoinDal dalCoin;

        public CoinManager(ICoinDal dalCoin)
        {
            this.dalCoin = dalCoin;
        }

        public void TDelete(Coin t)
        {
            throw new NotImplementedException();
        }

        public Coin TGetById(int id)
        {
            return dalCoin.GetByID(id);
        }

        public List<Coin> TGetList()
        {
            return dalCoin.GetList();
        }

        public void TInsert(Coin t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Coin t)
        {
            throw new NotImplementedException();
        }
    }
}
